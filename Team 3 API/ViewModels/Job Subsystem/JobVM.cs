using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Job_Subsystem
{
    public class JobVM
    {
        public int Job_ID { get; set; }
        public string Job_Description { get; set; }
        public Nullable<int> Job_Status_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
    }
}