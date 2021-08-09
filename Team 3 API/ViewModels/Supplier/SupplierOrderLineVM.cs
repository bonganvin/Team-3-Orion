using OVS_Team_3_API.ViewModels.Product;
using OVS_Team_3_API.ViewModels.Raw_Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Supplier
{
    public class SupplierOrderLineVM
    {
        public int Supplier_Order_Line_ID { get; set; }
        public Nullable<int> Supplier_Order_ID { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public Nullable<int> Raw_Material_ID { get; set; }

        public virtual ProductVM Product { get; set; }
        public virtual RawMaterialVM Raw_Material { get; set; }
        public virtual SupplierOrderVM Supplier_Order { get; set; }
    }
}