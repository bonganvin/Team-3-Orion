using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class RawMaterial
    {
        public int RawMaterialId { get; set; }
        public string RawMaterialName { get; set; }
        public int QuantityOnHand { get; set; }
        public string RawMaterialDescription { get; set; }
        public int? UnitId { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
