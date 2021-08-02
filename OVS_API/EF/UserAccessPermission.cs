using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class UserAccessPermission
    {
        public UserAccessPermission()
        {
            Users = new HashSet<User>();
        }

        public int UserAccessPermissionId { get; set; }
        public string UserRoleName { get; set; }
        public string UserRoleDescription { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
