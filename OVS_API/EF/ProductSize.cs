using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class ProductSize
    {
        public ProductSize()
        {
            Colours = new HashSet<Colour>();
        }

        public int ProductSizeId { get; set; }
        public int? PriceId { get; set; }
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }

        public virtual Price Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<Colour> Colours { get; set; }
    }
}
