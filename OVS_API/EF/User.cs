using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public int? UserAccessPermissionId { get; set; }

        public virtual UserAccessPermission UserAccessPermission { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
