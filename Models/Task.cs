using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
