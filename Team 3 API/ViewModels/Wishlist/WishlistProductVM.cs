using OVS_Team_3_API.ViewModels.Order;
using OVS_Team_3_API.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Wishlist
{
    public class WishlistProductVM
    {
        public int Wishlist_Product_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public Nullable<int> Wishlist_ID { get; set; }
        public int Quantity { get; set; }

        public virtual ProductVM Product { get; set; }
        public virtual WishListVM Wishlist { get; set; }
    }
}