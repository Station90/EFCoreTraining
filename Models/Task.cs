using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreTraining.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
