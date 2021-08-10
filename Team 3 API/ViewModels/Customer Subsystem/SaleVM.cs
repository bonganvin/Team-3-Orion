using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels
{
    public class SaleVM : Controller
    {
        public int Sale_ID { get; set; }
        public System.DateTime Sale_Date { get; set; }
        public Nullable<int> Request_Quote_ID { get; set; }
    }
}