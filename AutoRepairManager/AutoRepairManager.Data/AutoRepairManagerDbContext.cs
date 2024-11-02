using Microsoft.EntityFrameworkCore;
using AutoRepairManager.Models;

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
    }
}
