using OVS_Team_3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Order
{
    public class OrderVM
    {
        public int Order_ID { get; set; }
        public System.DateTime Order_Date { get; set; }
        public System.DateTime Order_Finalizastion_Date { get; set; }
        public bool Delivery { get; set; }
        public Nullable<int> Customer_ID { get; set; }
        public Nullable<int> Order_Status_ID { get; set; }
        public Nullable<int> Employee_ID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}