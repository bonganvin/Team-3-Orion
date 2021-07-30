using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class SaleLine
    {
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
