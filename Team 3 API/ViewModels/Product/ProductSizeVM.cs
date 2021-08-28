using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Product
{
    public class ProductSizeVM
    {
        public int ProductSizeID { get; set; }
        public Nullable<int> PriceID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> SizeID { get; set; }
    }
}