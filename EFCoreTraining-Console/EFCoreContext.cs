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

        public virtual DbSet<StoredProcResult> SPResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
