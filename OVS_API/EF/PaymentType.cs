using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            OrderPayments = new HashSet<OrderPayment>();
            SalePayments = new HashSet<SalePayment>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeDescription { get; set; }
        public string PaymentTypeName { get; set; }

        public virtual ICollection<OrderPayment> OrderPayments { get; set; }
        public virtual ICollection<SalePayment> SalePayments { get; set; }
    }
}
