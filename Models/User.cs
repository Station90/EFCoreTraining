using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    public class User
    {
        public int Id { get; set; }
        public int DetailsId { get; set; }
        public virtual UserDetails Details{ get; set; }
        public string Login { get; set; }

        public virtual IList<Task> Tasks { get; set; }
    }
}
