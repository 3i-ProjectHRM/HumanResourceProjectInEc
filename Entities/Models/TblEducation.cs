using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblEducation
    {
        public TblEducation()
        {
            Users = new HashSet<TblUser>();
        }

        public Guid EducationId { get; set; }
        public string EducationInstitute { get; set; } = null!;
        public string Course { get; set; } = null!;
        public DateTime EducationStartDate { get; set; }
        public DateTime EducationEndDate { get; set; }
        public byte[]? Certifications { get; set; }

        public virtual ICollection<TblUser> Users { get; set; }
    }
}
