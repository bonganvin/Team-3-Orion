using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class WishlistProduct
    {
        public int? ProductId { get; set; }
        public int? WishlistId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Wishlist Wishlist { get; set; }
    }
}
