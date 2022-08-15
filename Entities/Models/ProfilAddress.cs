using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ProfilAddress
    {
        public ProfilAddress()
        {
            TblProfils = new HashSet<TblProfil>();
        }

        public Guid AddressId { get; set; }
        public string AdministrativeUnit { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public int? ApartamentNo { get; set; }
        public string CityName { get; set; } = null!;

        public virtual ICollection<TblProfil> TblProfils { get; set; }
    }
}
