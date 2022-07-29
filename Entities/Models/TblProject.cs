using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblProject
    {
        public TblProject()
        {
            Users = new HashSet<TblUser>();
        }

        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public int ProjectMemberNum { get; set; }

        public virtual ICollection<TblUser> Users { get; set; }
    }
}
