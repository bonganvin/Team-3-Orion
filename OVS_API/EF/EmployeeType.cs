using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public string EmployeeTypeDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
