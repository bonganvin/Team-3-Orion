using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Discount
    {
        public Discount()
        {
            CustomerTypes = new HashSet<CustomerType>();
        }

        public int DiscountId { get; set; }
        public string DiscountDescription { get; set; }
        public string DiscountName { get; set; }
        public decimal DiscountPercentage { get; set; }

        public virtual ICollection<CustomerType> CustomerTypes { get; set; }
    }
}
