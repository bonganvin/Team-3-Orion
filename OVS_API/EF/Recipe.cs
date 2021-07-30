using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeDescription { get; set; }
        public int QuantityProduced { get; set; }
        public string RecipeName { get; set; }
    }
}
