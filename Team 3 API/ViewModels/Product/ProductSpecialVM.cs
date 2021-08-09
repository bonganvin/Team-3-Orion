using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Product
{
    public class ProductSpecialVM
    {
        public int Product_Special_ID { get; set; }
        public Nullable<int> Product_Size_ID { get; set; }
        public Nullable<int> Special_ID { get; set; }
        public float Price_Amount { get; set; }

    }
}