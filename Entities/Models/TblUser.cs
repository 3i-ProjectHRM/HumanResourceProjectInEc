using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblHolidays = new HashSet<TblHoliday>();
            TblProfils = new HashSet<TblProfil>();
            Educations = new HashSet<TblEducation>();
            IdRoles = new HashSet<TblRole>();
            Projects = new HashSet<TblProject>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string UserFirstName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPhoneNumber { get; set; } = null!;
        public byte[] UserPassword { get; set; } = null!;
        public int? UserTotalHoliday { get; set; }
        public int? UserHolidayBalance { get; set; }
        public int? UserStatus { get; set; }

        public virtual ICollection<TblHoliday> TblHolidays { get; set; }
        public virtual ICollection<TblProfil> TblProfils { get; set; }

        public virtual ICollection<TblEducation> Educations { get; set; }
        public virtual ICollection<TblRole> IdRoles { get; set; }
        public virtual ICollection<TblProject> Projects { get; set; }
    }
}
