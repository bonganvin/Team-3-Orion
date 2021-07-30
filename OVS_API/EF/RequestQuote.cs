using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class RequestQuote
    {
        public RequestQuote()
        {
            Sales = new HashSet<Sale>();
        }

        public int RequestQuoteId { get; set; }
        public DateTime Date { get; set; }
        public int? QuoteStatusId { get; set; }

        public virtual QuoteStatus QuoteStatus { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
