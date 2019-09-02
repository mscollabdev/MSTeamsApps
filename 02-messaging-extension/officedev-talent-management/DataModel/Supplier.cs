using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace officedev_talent_management.DataModel
{
    public class Supplier
    {
        public string Title { get; set; }
        public string ReqId { get; set; }
        public string OrderLocation { get; set; }
        public string Distance { get; set; }
        public string ETA { get; set; }
    }
}