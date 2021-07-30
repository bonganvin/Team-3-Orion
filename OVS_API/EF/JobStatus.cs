using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class JobStatus
    {
        public JobStatus()
        {
            Jobs = new HashSet<Job>();
        }

        public int JobStatusId { get; set; }
        public string JobStatusDescription { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
