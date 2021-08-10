using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels
{
    public class SaleLineVM : Controller
    {
        // GET: SaleLineVM
        public int Sale_Line_ID { get; set; }
        public Nullable<int> Sale_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public int Quantity { get; set; }
    }
}