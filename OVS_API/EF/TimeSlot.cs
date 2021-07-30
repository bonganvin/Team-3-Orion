using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartingTime { get; set; }
        public TimeSpan EndingTime { get; set; }
    }
}
