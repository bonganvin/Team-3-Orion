using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class SupplierOrderLine
    {
        public int? SupplierOrderId { get; set; }
        public int Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? RawMaterialId { get; set; }

        public virtual Product Product { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public virtual SupplierOrder SupplierOrder { get; set; }
    }
}
