using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels
{
    public class SalePaymentVM : Controller
    {
        // GET: SalePaymentVM
        public int Sale_Payment_ID { get; set; }
        public double Sale_Payment_Amount { get; set; }
        public System.DateTime Sale_Payment_Date { get; set; }
        public Nullable<int> Sale_Payment_Status_ID { get; set; }
        public Nullable<int> Sale_ID { get; set; }
        public Nullable<int> Payment_Type_ID { get; set; }
        public Nullable<int> Register_ID { get; set; }
    }
}