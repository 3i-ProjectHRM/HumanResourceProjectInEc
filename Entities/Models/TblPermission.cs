using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblPermission
    {
        public Guid PermissionsId { get; set; }
        public string PermissionsLabel { get; set; } = null!;
        public Guid Idrole { get; set; }

        public virtual TblRole IdroleNavigation { get; set; } = null!;
    }
}
