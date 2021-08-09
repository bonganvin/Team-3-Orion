using OVS_Team_3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Credit_Note
{
    public class CreditNoteVM
    {
        public int CreditNoteID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ReturnOrderRequestID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Return_Order_Request ReturnOrderRequest { get; set; }
    }
}