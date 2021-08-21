using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Job_Subsystem
{
    public class Job_TaskVM
    {
        public int Job_task_ID { get; set; }
        public Nullable<int> Job_ID { get; set; }
        public Nullable<int> Task_ID { get; set; }
        public Nullable<int> Job_Task_Status_ID { get; set; }
        public Nullable<int> Job_Task_Type_ID { get; set; }
    }
}