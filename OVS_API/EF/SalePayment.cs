using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class SalePayment
    {
        public int SalePaymentId { get; set; }
        public double SalePaymentAmount { get; set; }
        public DateTime SalePaymentDate { get; set; }
        public int? SalePaymentStatus { get; set; }
        public int? SaleId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? RegisterId { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual CashRegister Register { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual SalePaymentStatus SalePaymentStatusNavigation { get; set; }
    }
}
