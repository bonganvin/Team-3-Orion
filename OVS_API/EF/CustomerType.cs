using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
        }

        public int CustomerTypeId { get; set; }
        public string CustomerTypeDescription { get; set; }
        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
