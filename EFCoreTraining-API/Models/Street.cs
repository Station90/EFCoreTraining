using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class Street
    {
        private readonly ILazyLoader lazyLoader;
        public Street(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
            PostalCodeStreets = new HashSet<PostalCodeStreet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        private IList<PostalCode> postalCodes;
        public IList<PostalCode> PostalCodes 
        {
            get => lazyLoader.Load(this, ref postalCodes);
            set => postalCodes = value;
        }

        private ICollection<PostalCodeStreet> postalCodeStreets;
        public virtual ICollection<PostalCodeStreet> PostalCodeStreets 
        {
            get => lazyLoader.Load(this, ref postalCodeStreets);
            set => postalCodeStreets = value;
        }
    }
}
