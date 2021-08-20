using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Job_Subsystem
{
    public class Job_InstanceVM
    {
        public int Job_Instance_ID { get; set; }
        public Nullable<int> Job_task_ID { get; set; }
        public Nullable<int> Shift_Branch_Employee_ID { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }

    }
}