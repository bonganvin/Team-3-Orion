using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class SupplierOrder
    {
        public int SupplierOrderId { get; set; }
        public string SupplierOrderDescription { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
