using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels.Customer_Subsystem
{
    public class RequestQuoteVM : Controller
    {
        // GET: RequestOrderVM
        public int Request_Quote_ID { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Quote_Status_ID { get; set; }

    }
}