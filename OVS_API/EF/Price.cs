using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Price
    {
        public Price()
        {
            ProductSizes = new HashSet<ProductSize>();
        }

        public int PriceId { get; set; }
        public float PriceAmount { get; set; }
        public DateTime PriceDate { get; set; }

        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
