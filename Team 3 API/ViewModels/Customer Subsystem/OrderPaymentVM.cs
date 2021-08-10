using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels.Customer_Subsystem
{
    public class OrderPaymentVM : Controller
    {
        // GET: OrderPaymentVM
        public int Order_Payment_ID { get; set; }
        public int Order_Payment_Amount { get; set; }
        public System.DateTime Order_Payment_Date { get; set; }
        public Nullable<int> Payment_Type_ID { get; set; }
        public Nullable<int> Order_Payment_Status_ID { get; set; }
        public Nullable<int> Order_ID { get; set; }
    }
}