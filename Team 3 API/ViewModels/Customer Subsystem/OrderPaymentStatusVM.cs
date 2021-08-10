using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels.Customer_Subsystem
{
    public class OrderPaymentStatusVM : Controller
    {
        // GET: OrderPaymentStatusVM
        public int Order_Payment_Status_ID { get; set; }
        public string Order_Payment_Status_Description { get; set; }
    }
}