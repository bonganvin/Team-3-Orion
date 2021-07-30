using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class ReturnOrderRequest
    {
        public ReturnOrderRequest()
        {
            CreditNotes = new HashSet<CreditNote>();
        }

        public int ReturnOrderRequestId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public DateTime RequestOrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<CreditNote> CreditNotes { get; set; }
    }
}
