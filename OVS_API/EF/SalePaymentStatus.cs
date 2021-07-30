using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class SalePaymentStatus
    {
        public SalePaymentStatus()
        {
            SalePayments = new HashSet<SalePayment>();
        }

        public int SalePaymentStatusId { get; set; }
        public string SalePaymentStatusDesc { get; set; }

        public virtual ICollection<SalePayment> SalePayments { get; set; }
    }
}
