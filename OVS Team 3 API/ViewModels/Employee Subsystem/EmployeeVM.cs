using OVS_Team_3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Employee_Subsystem
{
    public class EmployeeVM
    {
        public int EmployeeID { get; set; }
        public string EmployeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeEmailAddress { get; set; }
        public Nullable<int> EmployeeTypeID { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Employee_Type EmployeeType { get; set; }
        public virtual User User { get; set; }
    }
}