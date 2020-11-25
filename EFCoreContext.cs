using EFCoreTraining.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTraining
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Task> Tasks { get; set; }


        public DbSet<Street> Streets { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasOne(x => x.Details).WithOne(x => x.User);
            modelBuilder.Entity<User>().HasMany(x => x.Tasks).WithOne(x => x.User);


            modelBuilder.Entity<Street>().HasMany(x => x.PostalCodes).WithMany(x => x.Streets);
        }
    }
}
