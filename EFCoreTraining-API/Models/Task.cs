using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class Task
    {
        private readonly ILazyLoader lazyLoader;

        public Task(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

        private User user;
        public virtual User User 
        {
            get => lazyLoader.Load(this, ref user);
            set => user = value;
        }
    }
}
