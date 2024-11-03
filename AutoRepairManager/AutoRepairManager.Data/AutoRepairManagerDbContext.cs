using Microsoft.EntityFrameworkCore;
using AutoRepairManager.Models;
using AutoRepairManager.Models.Models;

namespace AutoRepairManager.Data
{
    public class AutoRepairManagerDbContext : DbContext
    {
        public AutoRepairManagerDbContext(DbContextOptions<AutoRepairManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RepairHistory> RepairHistories { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer model
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Username).
                IsRequired()
                .HasMaxLength(50);
                
                entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(c => c.Phone)
                .HasMaxLength(20);
                
            });

            // Car model
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Make)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(c => c.LicensePlate)
                .IsRequired()
                .HasMaxLength(10);

                // Relationships
                entity.HasOne(c => c.Customer)
                      .WithMany(cu => cu.Cars)
                      .HasForeignKey(c => c.CustomerId);
            });

            // RepairHistory model
            modelBuilder.Entity<RepairHistory>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.RepairDate).IsRequired();
                entity.Property(r => r.Description).IsRequired().HasMaxLength(500);
                entity.Property(r => r.Cost).HasColumnType("decimal(18,2)");

                // Relationships
                entity.HasOne(r => r.Car)
                      .WithMany(c => c.RepairHistory)
                      .HasForeignKey(r => r.CarId);
            });

            // RepairOrder model
            modelBuilder.Entity<RepairOrder>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.OrderDate).IsRequired();
                entity.Property(r => r.Status).IsRequired().HasMaxLength(20);

                // Relationships
                entity.HasOne(r => r.Customer)
                      .WithMany(c => c.RepairOrders)
                      .HasForeignKey(r => r.CustomerId);

                entity.HasOne(r => r.Car)
                      .WithMany(c => c.RepairOrders)
                      .HasForeignKey(r => r.CarId);

                entity.HasOne(r => r.ServiceType)
                      .WithMany(s => s.RepairOrders)
                      .HasForeignKey(r => r.ServiceTypeId);
            });

            // ServiceType model
            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
                entity.Property(s => s.Price).HasColumnType("decimal(18,2)");
            });

            // Invoice model
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.InvoiceDate).IsRequired();
                entity.Property(i => i.Amount).HasColumnType("decimal(18,2)");
                entity.Property(i => i.InvoiceStatus).IsRequired().HasMaxLength(20);

                // Relationships
                entity.HasOne(i => i.Customer)
                      .WithMany(c => c.Invoices)
                      .HasForeignKey(i => i.CustomerId);

                entity.HasOne(i => i.RepairOrder)
                      .WithMany(r => r.Invoices)
                      .HasForeignKey(i => i.RepairOrderId);
            });

            // User model
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Role).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
