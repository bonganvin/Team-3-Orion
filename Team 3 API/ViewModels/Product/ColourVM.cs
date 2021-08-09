using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Product
{
    public class ColourVM
    {
        public int Colour_ID { get; set; }
        public string Colour_Description { get; set; }
        public Nullable<int> Product_Size_ID { get; set; }

        public virtual ProductSizeVM Product_Size { get; set; }
    }
}