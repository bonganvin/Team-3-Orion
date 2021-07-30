using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class ShiftType
    {
        public ShiftType()
        {
            Shifts = new HashSet<Shift>();
        }

        public int ShiftTypeId { get; set; }
        public string ShiftTypeDescription { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
