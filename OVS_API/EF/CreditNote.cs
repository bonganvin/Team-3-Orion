using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class CreditNote
    {
        public int CreditNoteId { get; set; }
        public int? CustomerId { get; set; }
        public int? ReturnOrderRequestId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ReturnOrderRequest ReturnOrderRequest { get; set; }
    }
}
