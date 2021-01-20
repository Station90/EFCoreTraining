using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class PostalCode
    {
        public PostalCode()
        {
            PostalCodeStreets = new HashSet<PostalCodeStreet>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public IList<Street> Streets { get; set; }

        public virtual ICollection<PostalCodeStreet> PostalCodeStreets { get; set; }
    }
}
