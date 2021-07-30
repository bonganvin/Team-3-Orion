using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class QuoteStatus
    {
        public QuoteStatus()
        {
            RequestQuotes = new HashSet<RequestQuote>();
        }

        public int QuoteStatusId { get; set; }
        public string QuoteStatusDescription { get; set; }

        public virtual ICollection<RequestQuote> RequestQuotes { get; set; }
    }
}
