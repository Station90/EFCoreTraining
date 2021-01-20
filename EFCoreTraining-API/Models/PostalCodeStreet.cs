using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class PostalCodeStreet
    {
        private readonly ILazyLoader lazyLoader;

        public PostalCodeStreet(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        
        public int PostalCodesId { get; set; }
        public int StreetsId { get; set; }
        private PostalCode postalCodes;
        public virtual PostalCode PostalCodes 
        {
            get => lazyLoader.Load(this, ref postalCodes);
            set => postalCodes = value;
        }
        private Street streets;
        public virtual Street Streets 
        {
            get => lazyLoader.Load(this, ref streets);
            set => streets = value;
        }
    }
}
