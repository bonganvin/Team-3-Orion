using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Product
{
    public class ProductSizeVM
    {
        public int Product_Size_ID { get; set; }
        public Nullable<int> Price_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public Nullable<int> Size_ID { get; set; }
    }
}