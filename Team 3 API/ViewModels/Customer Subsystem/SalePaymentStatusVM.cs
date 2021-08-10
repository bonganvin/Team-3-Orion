using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels
{
    public class SalePaymentStatusVM : Controller
    {
        // GET: SalePaymentStatusVM
        public int Sale_Payment_Status_ID { get; set; }
        public string Sale_Payment_Status_Desc { get; set; }
    }
}