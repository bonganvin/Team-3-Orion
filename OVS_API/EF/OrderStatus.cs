using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatusDescription { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
