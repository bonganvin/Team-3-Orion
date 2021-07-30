using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class JobTask
    {
        public int? JobId { get; set; }
        public int? TaskId { get; set; }
        public int? JobTaskStatusId { get; set; }
        public int? JobTaskTypeId { get; set; }

        public virtual Job Job { get; set; }
        public virtual JobTaskStatus JobTaskStatus { get; set; }
        public virtual JobTaskType JobTaskType { get; set; }
        public virtual Task Task { get; set; }
    }
}
