using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblHoliday
    {
        public Guid HolidayId { get; set; }
        public string HolidayType { get; set; } = null!;
        public DateTime? HolidayStartDate { get; set; }
        public DateTime? HolidayFinishDate { get; set; }
        public int? CompensationDay { get; set; }
        public byte[]? SickRaport { get; set; }
        public Guid Iduser { get; set; }

        public virtual TblUser IduserNavigation { get; set; } = null!;
    }
}
