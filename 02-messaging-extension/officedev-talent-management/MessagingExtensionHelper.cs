/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT license.
 */
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams;
using Microsoft.Bot.Connector.Teams.Models;
using Newtonsoft.Json.Linq;
using OfficeDev.Talent.Management;
using System.Globalization;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using officedev_talent_management.DataModel;

namespace officedev_talent_management
{
  public class MessagingExtensionHelper
  {
    public static async Task<ComposeExtensionResponse> CreateResponse(Activity activity)
    {
      ComposeExtensionResponse response = null;

      var query = activity.GetComposeExtensionQueryData();
      JObject data = activity.Value as JObject;

      //Check to make sure a query was actually made:
      if (query.CommandId == null || query.Parameters == null)
      {
        return null;
      }
      else if (query.Parameters.Count > 0)
      {
        // query.Parameters has the parameters sent by client
        var results = new ComposeExtensionResult()
        {
          AttachmentLayout = "list",
          Type = "result",
          Attachments = new List<ComposeExtensionAttachment>(),
        };


        if (query.CommandId == "searchInventory")
        {
            InventoryDataController inventoryDataController = new InventoryDataController();
            IEnumerable<Inventory> inventories;

            if (query.Parameters[0].Name == "initialRun")
            {
                // Default query => list all
                inventories = inventoryDataController.ListInventory(10);
            }
            else
            {
                // Basic search.
                string title = query.Parameters[0].Value.ToString().ToLower();
                inventories = inventoryDataController.ListInventory(10).Where(x => x.Title.ToLower().Contains(title));
            }

                    // Generate cards for the response.
            foreach (Inventory inv in inventories)
            {
                var card = CardHelper.CreateCardForInventory(inv, true);

                var composeExtensionAttachment = card.ToAttachment().ToComposeExtensionAttachment();
                results.Attachments.Add(composeExtensionAttachment);
            }
        }

        else if(query.CommandId == "searchSupplier")
                {
                    SupplierDataController supplierDataController = new SupplierDataController();
                    IEnumerable<Supplier> suppliers;

                    if (query.Parameters[0].Name == "initialRun")
                    {
                        // Default query => list all
                        suppliers = supplierDataController.ListSupplier(10);
                    }
                    else
                    { 
                        string title = query.Parameters[0].Value.ToString().ToLower();
                        suppliers = supplierDataController.ListSupplier(10).Where(x => x.Title.ToLower().Contains(title));
                    }

                    foreach (Supplier sup in suppliers)
                    {
                        var card = CardHelper.CreateCardForSupplier(sup, true);

                        var composeExtensionAttachment = card.ToAttachment().ToComposeExtensionAttachment();
                        results.Attachments.Add(composeExtensionAttachment);
                    }

                }

        response = new ComposeExtensionResponse()
        {
          ComposeExtension = results
        };
      }

      return response;
    }
  }
}