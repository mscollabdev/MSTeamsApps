/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT license.
 */
using AdaptiveCards;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams.Models;
using Newtonsoft.Json.Linq;
using OfficeDev.Talent.Management;
using officedev_talent_management.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace officedev_talent_management
{
  public class CardHelper
  {
    /// <summary>
    /// JSON template.
    /// </summary>
    private static string cardJson = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/cardtemplate.json"));

    #region Card Helpers

        public static ThumbnailCard CreateCardForInventory(Inventory inventory, bool includeButtons = false)
        {
            var random = new Random();

            ThumbnailCard card = new ThumbnailCard()
            {                
                Title = inventory.Title,
                Subtitle = $"Description : {inventory.InventoryDescription}",
                Text = $"Req ID: {inventory.ReqId}",
            };

            if (includeButtons)
            {
                card.Buttons = new List<CardAction>()
                  {
                    new CardAction("openUrl", "See details", null, "https://www.bing.com/search?q=" + inventory.Title),
                    new CardAction("messageBack", "Order Inventory", null, inventory.ReqId, "order inventory", $"You have successfully placed request for {inventory.Title}, your request ID is - {inventory.ReqId}"),
                  };
            }

            card.Images = new List<CardImage>()
            {
                new CardImage("https://collabmst.azurewebsites.net/" + inventory.Images)
            };

            return card;
        }

        public static ThumbnailCard CreateCardForSupplier(Supplier supplier, bool includeButtons = false)
        {
            var random = new Random();

            ThumbnailCard card = new ThumbnailCard()
            {
                Title = supplier.Title,
                Subtitle = $"Type : {supplier.OrderLocation} , Distance : {supplier.Distance}",
                Text = $"Please note the ETA {supplier.ETA} and Req ID: {supplier.ReqId}",
            };

            if (includeButtons)
            {
                card.Buttons = new List<CardAction>()
                  {
                    new CardAction("openUrl", "Contact Supplier", null, "https://www.bing.com/"),                 
                  };
            }            

            return card;
        }

        #endregion
    }
}