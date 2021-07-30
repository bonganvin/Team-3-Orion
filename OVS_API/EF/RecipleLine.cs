using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class RecipleLine
    {
        public int Quantity { get; set; }
        public int? RecipeId { get; set; }
        public int? RawMaterialId { get; set; }
        public int? RecipeLineUnitId { get; set; }

        public virtual RawMaterial RawMaterial { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual RecipeLineUnit RecipeLineUnit { get; set; }
    }
}
