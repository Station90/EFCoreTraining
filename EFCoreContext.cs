using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using EFCoreTraining.Models;

namespace EFCoreTraining
{
    public class EFCoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Task> Tasks { get; set; }


        public DbSet<Street> Streets { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasRequired(x => x.Details).WithRequiredDependent(x => x.User);
            modelBuilder.Entity<User>().HasMany(x => x.Tasks).WithRequired(x => x.User);


            modelBuilder.Entity<Street>().HasMany(x => x.PostalCodes).WithMany(x => x.Streets);
        }
    }
}
