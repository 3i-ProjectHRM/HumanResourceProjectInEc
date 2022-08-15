using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblProfil
    {
        public Guid ProfilId { get; set; }
        public string ProfilUsername { get; set; } = null!;
        public string ProfilDescription { get; set; } = null!;
        public string ProfilPhone2 { get; set; } = null!;
        public string ProfilAddress { get; set; } = null!;
        public byte[]? ProfilArchive { get; set; }
        public string ProfilStatus { get; set; } = null!;
        public Guid Iduser { get; set; }
        public Guid IdprofilAddress { get; set; }

        public virtual ProfilAddress IdprofilAddressNavigation { get; set; } = null!;
        public virtual TblUser IduserNavigation { get; set; } = null!;
    }
}
