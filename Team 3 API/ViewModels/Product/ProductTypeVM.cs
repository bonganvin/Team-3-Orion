using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Product
{
    public class ProductTypeVM
    {
        public int Product_Type_ID { get; set; }
        public string Product_Type_Name { get; set; }
        public Nullable<int> Product_Category_ID { get; set; }
    }
}