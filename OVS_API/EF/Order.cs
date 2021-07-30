using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Order
    {
        public Order()
        {
            OrderPayments = new HashSet<OrderPayment>();
            ReturnOrderRequests = new HashSet<ReturnOrderRequest>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderFinalizastionDate { get; set; }
        public bool Delivery { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderPayment> OrderPayments { get; set; }
        public virtual ICollection<ReturnOrderRequest> ReturnOrderRequests { get; set; }
    }
}
