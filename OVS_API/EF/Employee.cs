using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeEmailAddress { get; set; }
        public int? EmployeeTypeId { get; set; }
        public int? UserId { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
