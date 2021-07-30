using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? UserAccessPermissionId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        public virtual UserAccessPermission UserAccessPermission { get; set; }
    }
}
