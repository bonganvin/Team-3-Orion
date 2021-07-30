using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Unit
    {
        public Unit()
        {
            RawMaterials = new HashSet<RawMaterial>();
        }

        public int UnitId { get; set; }
        public int UnitQuantity { get; set; }

        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
    }
}
