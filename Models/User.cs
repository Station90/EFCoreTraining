using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTraining.Models
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string DetailsId { get; set; }
        public string Login { get; set; }

        public virtual UserDetail Details { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
