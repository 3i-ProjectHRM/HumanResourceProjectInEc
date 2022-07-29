using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblPermissions = new HashSet<TblPermission>();
            IdUsers = new HashSet<TblUser>();
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<TblPermission> TblPermissions { get; set; }

        public virtual ICollection<TblUser> IdUsers { get; set; }
    }
}
