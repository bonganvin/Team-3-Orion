using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class OrderPayment
    {
        public int OrderPaymentId { get; set; }
        public int OrderPaymentAmount { get; set; }
        public DateTime OrderPaymentDate { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? OrderPaymentStatus { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual OrderPaymentStatus OrderPaymentStatusNavigation { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
