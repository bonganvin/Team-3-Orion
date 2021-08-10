using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels
{
    public class ReturnSaleRequestVM : Controller
    {
        // GET: ReturnSaleRequestVM
        public int Return_Sale_Request_ID { get; set; }
        public System.DateTime Return_Request_Date { get; set; }
        public Nullable<int> Customer_ID { get; set; }
    }
}