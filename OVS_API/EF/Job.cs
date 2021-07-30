using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Job
    {
        public int JobId { get; set; }
        public string JobDescription { get; set; }
        public int? JobStatusId { get; set; }
        public int? ProductId { get; set; }

        public virtual JobStatus JobStatus { get; set; }
        public virtual Product Product { get; set; }
    }
}
