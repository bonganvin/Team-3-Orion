using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class ProductSpecial
    {
        public int? ProductSizeId { get; set; }
        public int? SpecialId { get; set; }
        public float PriceAmount { get; set; }

        public virtual ProductSize ProductSize { get; set; }
        public virtual Special Special { get; set; }
    }
}
