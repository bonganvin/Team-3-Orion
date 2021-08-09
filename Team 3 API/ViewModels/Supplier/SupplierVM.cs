using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Supplier
{
    public class SupplierVM
    {
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Phone_Number { get; set; }
        public string Supplier_Address { get; set; }
    }
}