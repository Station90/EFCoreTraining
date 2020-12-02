using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTraining.Models
{
    public partial class PostalCodeStreet
    {
        public int PostalCodesId { get; set; }
        public int StreetsId { get; set; }

        public virtual PostalCode PostalCodes { get; set; }
        public virtual Street Streets { get; set; }
    }
}
