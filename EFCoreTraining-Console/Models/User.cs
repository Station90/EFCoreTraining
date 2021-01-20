using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    public class User
    {
        public int Id { get; set; }
        public UserDetails Details{ get; set; }
        public string Login { get; set; }
        public IList<Task> Tasks { get; set; }
    }
}
