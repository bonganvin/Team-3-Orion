using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Supplier
{
    public class SupplierOrderVM
    {
        public int Supplier_Order_ID { get; set; }
        public string Supplier_Order_Description { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
    }
}