using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IsadMholt
{
    public partial class ISAD251_MHoltContext : DbContext
    {
        public ISAD251_MHoltContext()
        {
        }

        public ISAD251_MHoltContext(DbContextOptions<ISAD251_MHoltContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemsOrdered> ItemsOrdered { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=ISAD251_MHolt;User Id=MHolt; Password=ISAD251_22201571");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer).ValueGeneratedNever();

                entity.Property(e => e.CookieId)
                    .HasColumnName("CookieID")
                    .HasMaxLength(10);

                entity.Property(e => e.Expires).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.IdItem);

                entity.Property(e => e.IdItem).ValueGeneratedNever();

                entity.Property(e => e.Catagory).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Price).HasMaxLength(10);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<ItemsOrdered>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.Property(e => e.IdItem).HasMaxLength(10);

                entity.Property(e => e.Quantity).HasMaxLength(10);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.Property(e => e.Date).HasMaxLength(10);

                entity.Property(e => e.IdCustomer).HasMaxLength(10);

                entity.Property(e => e.Price).HasMaxLength(10);

                entity.Property(e => e.Time).HasMaxLength(10);
            });
        }
    }
}
