using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTraining.Models
{
    public partial class Street
    {
        public Street()
        {
            PostalCodeStreets = new HashSet<PostalCodeStreet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PostalCodeStreet> PostalCodeStreets { get; set; }
    }
}
