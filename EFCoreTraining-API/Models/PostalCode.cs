using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class PostalCode
    {
        private readonly ILazyLoader lazyLoader;
        
        public PostalCode(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
            PostalCodeStreets = new HashSet<PostalCodeStreet>();
        }

        public int Id { get; set; }
        
        public string Code { get; set; }
        private IList<Street> streets;
        public IList<Street> Streets 
        {
            get => lazyLoader.Load(this, ref streets);
            set => streets = value;
        }

        private ICollection<PostalCodeStreet> postalCodeStreets;
        public virtual ICollection<PostalCodeStreet> PostalCodeStreets 
        {
            get => lazyLoader.Load(this, ref postalCodeStreets);
            set => postalCodeStreets = value;
        }
    }
}
