using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
