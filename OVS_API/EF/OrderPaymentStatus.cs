using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class OrderPaymentStatus
    {
        public OrderPaymentStatus()
        {
            OrderPayments = new HashSet<OrderPayment>();
        }

        public int OrderPaymentStatusId { get; set; }
        public string OrderPaymentStatusDescription { get; set; }

        public virtual ICollection<OrderPayment> OrderPayments { get; set; }
    }
}
