using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASPNETDZ2.Data
{
    public partial class ASPNETCarsContext : DbContext
    {
        public ASPNETCarsContext()
        {
        }

        public ASPNETCarsContext(DbContextOptions<ASPNETCarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ASPNETCars;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarImage)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
