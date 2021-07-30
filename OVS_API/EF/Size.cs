using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Size
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSize>();
        }

        public int SizeId { get; set; }
        public string SizeDescription { get; set; }

        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
