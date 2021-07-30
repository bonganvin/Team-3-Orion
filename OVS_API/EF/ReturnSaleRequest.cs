using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class ReturnSaleRequest
    {
        public int ReturnSaleRequestId { get; set; }
        public DateTime ReturnRequestDate { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
