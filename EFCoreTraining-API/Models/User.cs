using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class User
    {
        private readonly ILazyLoader lazyLoader;
        public User(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string DetailsId { get; set; }
        public string Login { get; set; }
        private UserDetail details;
        public virtual UserDetail Details 
        {
            get => lazyLoader.Load(this, ref details);
            set => details = value;
        }
        private ICollection<Task> tasks;
        public virtual ICollection<Task> Tasks 
        {
            get => lazyLoader.Load(this, ref tasks);
            set => tasks = value;
        }
    }
}
