using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Wishlist
    {
        public int WishlistId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
