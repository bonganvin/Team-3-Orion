using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductTypes = new HashSet<ProductType>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
