using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class ReturnSaleRequestSaleLine
    {
        public int Quantity { get; set; }
        public string ReturnSaleReason { get; set; }
        public int? ReturnSaleRequestId { get; set; }
        public int? ProductId { get; set; }
        public int? Sale { get; set; }

        public virtual Product Product { get; set; }
        public virtual ReturnSaleRequest ReturnSaleRequest { get; set; }
        public virtual Sale SaleNavigation { get; set; }
    }
}
