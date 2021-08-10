using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels.Customer_Subsystem
{
    public class QuoteLineVM : Controller
    {
        // GET: QuoteLineVM
        public int Quote_Line_ID { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public Nullable<int> Request_Quote_ID { get; set; }

    }
}