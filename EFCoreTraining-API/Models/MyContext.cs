using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreTraining_API.Models
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<PostalCodeStreet> PostalCodeStreets { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\MOTORMSVR2;Database=EFCoreTrainingDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PostalCodeStreet>(entity =>
            {
                entity.HasKey(e => new { e.PostalCodesId, e.StreetsId });

                entity.ToTable("PostalCodeStreet");

                entity.HasIndex(e => e.StreetsId, "IX_PostalCodeStreet_StreetsId");

                entity.HasOne(d => d.PostalCodes)
                    .WithMany(p => p.PostalCodeStreets)
                    .HasForeignKey(d => d.PostalCodesId);

                entity.HasOne(d => d.Streets)
                    .WithMany(p => p.PostalCodeStreets)
                    .HasForeignKey(d => d.StreetsId);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Tasks_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.DetailsId, "IX_Users_DetailsId");

                entity.HasOne(d => d.Details)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DetailsId);
            });

            modelBuilder.Entity<PostalCode>().HasMany(x => x.Streets).WithMany(x => x.PostalCodes)
                .UsingEntity<PostalCodeStreet>(
                    x => x.HasOne<Street>().WithMany().HasForeignKey(y => y.PostalCodesId),
                    x => x.HasOne<PostalCode>().WithMany().HasForeignKey(y => y.StreetsId));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
