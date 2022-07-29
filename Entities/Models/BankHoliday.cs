using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class BankHoliday
    {
        public Guid BankHolidayId { get; set; }
        public string BankHolidayTitle { get; set; } = null!;
        public DateTime BankHolidayStartDate { get; set; }
        public DateTime BankHolidayFinishDate { get; set; }
    }
}
