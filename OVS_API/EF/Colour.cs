using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Colour
    {
        public int ColourId { get; set; }
        public string ColourDescription { get; set; }
        public int? ProductSizeId { get; set; }

        public virtual ProductSize ProductSize { get; set; }
    }
}
