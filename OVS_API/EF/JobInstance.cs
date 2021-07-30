using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class JobInstance
    {
        public int? JobId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShiftId { get; set; }
        public int? BranchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Job Job { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
