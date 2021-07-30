using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Product
    {
        public Product()
        {
            Jobs = new HashSet<Job>();
            ProductSizes = new HashSet<ProductSize>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }
        public int? QuantityOnHand { get; set; }
        public int? ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
