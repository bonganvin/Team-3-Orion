using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Special
    {
        public int SpecialId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
