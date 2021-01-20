using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class UserDetail
    {
        private readonly ILazyLoader lazyLoader;
        public UserDetail(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
            Users = new HashSet<User>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private ICollection<User> users;
        public virtual ICollection<User> Users 
        {
            get => lazyLoader.Load(this, ref users);
            set => users = value;
        }
    }
}
