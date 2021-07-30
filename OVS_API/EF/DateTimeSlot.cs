using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class DateTimeSlot
    {
        public int? ShiftId { get; set; }
        public int? TimeSlotId { get; set; }
        public int? DateId { get; set; }

        public virtual Date Date { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
