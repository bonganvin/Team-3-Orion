using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels.Customer_Subsystem
{
    public class PaymentTypeVM : Controller
    {
        // GET: PaymentTypeVM
        public int Payment_Type_ID { get; set; }
        public string Payment_Type_Description { get; set; }
        public string Payment_Type_Name { get; set; }
    }
}