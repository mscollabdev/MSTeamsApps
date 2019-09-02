/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT license.
 */
using Bogus;
using officedev_talent_management.DataModel;
using System;
using System.Collections.Generic;

namespace OfficeDev.Talent.Management
{
  public static class Constants
  {
    public static List<string> Titles = new List<string>
  {
    "Graphics Artist",
    "Senior Content Writer",
    "Senior Program Manager",
    "Software Developer II",
    "Principal Product Manager",
    "Marketing Manager",
    "Development Lead",
    "UX Designer"
  };

     public static List<string> Inventory = new List<string>
  {
    "Rotor",
    "Injector",
    "Nitrogen Gas",
    "Capacitor",
    "Shafts",
    "Switchboard",
    "Wires",
    "Coolant"
  };

        public static List<string> Supplier = new List<string>
  {
    "Alpha Suppliers",
    "Beta Suppliers",
    "Gamma Suppliers",
    "Delta Suppliers"
  };

        public static List<string> Distance = new List<string>
  {
    "< 1km",
    "1km to 5km",
    "5km to 10km",
    "> 10km"
  };

        public static List<string> ETA = new List<string>
  {
    "1 day",
    "2 to 3 days",
    "4 to 7 days",
    "> 7 days"
  };

        public static List<string> OrderLocation = new List<string>
  {
    "In-House",
    "3rd Party Vendor"
  };

        public static List<string> Stages = new List<string>
  {
    "Applied",
    "Interviewing",
    "Pending",
    "Offered"
  };

    public static List<string> Locations = new List<string>
  {
    "Mumbai",
    "San Francisco",
    "London",
    "Singapore",
    "Dubai",
    "Frankfurt"
  };

        public static List<string> Images = new List<string>
        {
            "/images/image1.png",
            "/images/image2.png",
            "/images/image3.png",
            "/images/image4.png",
            "/images/image5.png",
            "/images/image6.png",
            "/images/image7.png",
            "/images/image8.png",
            "/images/image9.png",
        };

  }

  public class InventoryDataController
    {
        public List<Inventory> ListInventory(int count)
        {
            List<Inventory> resp = new List<Inventory>();

            for (int i = 0; i < count; i++)
            {
                resp.Add(GenerateInventory());
            }
            return resp;
        }

        private Inventory GenerateInventory()
        {
            Random r = new Random();
            var faker = new Faker();

            Inventory i = new Inventory()
            {
                Title = faker.PickRandom(Constants.Inventory),
                ReqId = Guid.NewGuid().ToString().Split('-')[0].ToUpper(),
                OrderLocation = faker.PickRandom(Constants.OrderLocation),
                InventoryDescription = "Description about the Inventory",
                Location = faker.PickRandom(Constants.Locations),
                Images = faker.PickRandom(Constants.Images),
            };

            return i;
        }
    }

   public class SupplierDataController
    {
        public List<Supplier> ListSupplier(int count)
        {
            List<Supplier> resp = new List<Supplier>();

            for (int i = 0; i < count; i++)
            {
                resp.Add(GenerateSupplier());
            }
            return resp;
        }

        private Supplier GenerateSupplier()
        {
            Random r = new Random();
            var faker = new Faker();

            Supplier s = new Supplier()
            {
                Title = faker.PickRandom(Constants.Supplier),
                ReqId = Guid.NewGuid().ToString().Split('-')[0].ToUpper(),
                OrderLocation = faker.PickRandom(Constants.OrderLocation),
                Distance = faker.PickRandom(Constants.Distance),  
                ETA = faker.PickRandom(Constants.ETA),
        };

            return s;
        }
}
}