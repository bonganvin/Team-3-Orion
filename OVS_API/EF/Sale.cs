using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Sale
    {
        public Sale()
        {
            SalePayments = new HashSet<SalePayment>();
        }

        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public int? RequestQuoteId { get; set; }

        public virtual RequestQuote RequestQuote { get; set; }
        public virtual ICollection<SalePayment> SalePayments { get; set; }
    }
}
