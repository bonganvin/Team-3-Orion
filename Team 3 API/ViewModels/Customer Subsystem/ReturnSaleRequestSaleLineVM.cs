using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels.Customer_Subsystem
{
    public class ReturnSaleRequestSaleLineVM : Controller
    {
        // GET: ReturnSaleRequestSaleLineVM
        public int Return_Sale_Request_Sale_Line_ID { get; set; }
        public string Return_Sale_Reason { get; set; }
        public Nullable<int> Return_Sale_Request_ID { get; set; }
        public Nullable<int> Sale_Line_ID { get; set; }
        public Nullable<int> Quantity { get; set; }
    }