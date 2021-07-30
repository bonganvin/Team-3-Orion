using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class JobInstanceTask
    {
        public int? JobId { get; set; }
        public int? TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Job Job { get; set; }
        public virtual Task Task { get; set; }
    }
}
