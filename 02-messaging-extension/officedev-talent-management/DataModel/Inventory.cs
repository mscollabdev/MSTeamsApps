using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace officedev_talent_management.DataModel
{
    public class Inventory
    {
        public string Title { get; set; }
        public string ReqId { get; set; }
        public string OrderLocation { get; set; }
        public string Location { get; set; }
        public string InventoryDescription { get; set; }

        public string Images { get; set; }
    }
}