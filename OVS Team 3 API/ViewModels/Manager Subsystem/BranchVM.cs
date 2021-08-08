using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Manager_Subsystem
{
    public class BranchVM
    {
        public int Branch_ID { get; set; }
        public string Branch_Name { get; set; }
        public int Branch_Location_Storage_Capacity { get; set; }
        public string Branch_Address { get; set; }
    }
}