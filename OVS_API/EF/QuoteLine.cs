using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class QuoteLine
    {
        public int Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? RequestQuoteId { get; set; }

        public virtual Product Product { get; set; }
        public virtual RequestQuote RequestQuote { get; set; }
    }
}
