using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public int? ShiftTypeId { get; set; }

        public virtual ShiftType ShiftType { get; set; }
    }
}
