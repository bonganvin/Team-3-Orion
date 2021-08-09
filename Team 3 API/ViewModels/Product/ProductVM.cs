using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Product
{
    public class ProductVM
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public byte[] Product_Image { get; set; }
        public Nullable<int> Quantity_on_hand { get; set; }
        public Nullable<int> Product_Type_ID { get; set; }
    }
}