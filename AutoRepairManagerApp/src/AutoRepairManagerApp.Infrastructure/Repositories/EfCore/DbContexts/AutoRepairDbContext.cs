using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Models.Relations;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoRepairManagerApp.Core.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;

public class AutoRepairDbContext : DbContext
{
    public DbSet<AutoRepair> AutoRepairs { get; set; }
    public DbSet<RepairLog> RepairLogs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserCars> UserCars { get; set; }
    public DbSet<RepairOrder> RepairOrders { get; set; }

    public AutoRepairDbContext(DbContextOptions<AutoRepairDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .Property(ur => ur.RoleId)
            .IsRequired();





        modelBuilder.Entity<UserCars>()
            .HasKey(uc => uc.UserId);

        modelBuilder.Entity<UserCars>()
            .Property(uc => uc.CarsId)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<IEnumerable<Guid>>(v, (JsonSerializerOptions)null) ?? new List<Guid>()
            )
            .IsRequired();
        




        modelBuilder.Entity<AutoRepair>()
            .HasKey(ar => ar.Id);

        modelBuilder.Entity<AutoRepair>()
            .Property(ar => ar.Location)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<(double Latitude, double Longitude)>(v, (JsonSerializerOptions)null)
            );

        _ = modelBuilder.Entity<AutoRepair>()
            .Property(ar => ar.ServiceTypeEnums)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<IEnumerable<ServiceTypeEnum>>(v, (JsonSerializerOptions)null) ?? new List<ServiceTypeEnum>()
            );

        modelBuilder.Entity<AutoRepair>()
            .HasKey(ar => ar.Id);

        modelBuilder.Entity<AutoRepair>()
            .Property(ar => ar.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<AutoRepair>()
            .Property(ar => ar.Location)
            .IsRequired();

        modelBuilder.Entity<AutoRepair>()
            .Property(ar => ar.Adress)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<AutoRepair>()
            .Property(ar => ar.ServiceTypeEnums)
            .IsRequired();

    
        modelBuilder.Entity<AutoRepair>()
            .Property(e => e.WorkingHours)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Dictionary<DayEnum, (TimeSpan, TimeSpan)>>(v, (JsonSerializerOptions)null)
            );

        modelBuilder.Entity<AutoRepair>()
            .Property(ar => ar.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15)
            .HasConversion(
                v => v,
                v => v);






        modelBuilder.Entity<Car>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Car>()
            .Property(c => c.Make)
            .IsRequired() 
            .HasMaxLength(100);

        modelBuilder.Entity<Car>()
            .Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Car>()
            .Property(c => c.CarPlate)
            .IsRequired() 
            .HasMaxLength(7)
            .HasConversion( v => v, v => v);

        modelBuilder.Entity<Car>()
            .HasMany(c => c.RepairHistory)
            .WithOne() 
            .HasForeignKey(rl => rl.CarId)
            .IsRequired(); 
    



        modelBuilder.Entity<RepairLog>()
            .HasKey(rl => rl.Id);

        modelBuilder.Entity<RepairLog>()
            .Property(rl => rl.CarId)
            .IsRequired(); 

        modelBuilder.Entity<RepairLog>()
            .Property(rl => rl.RepairDate)
            .IsRequired(); 

        modelBuilder.Entity<RepairLog>()
            .Property(rl => rl.Description)
            .IsRequired()
            .HasMaxLength(500); 

        modelBuilder.Entity<RepairLog>()
            .Property(rl => rl.Cost)
            .IsRequired()
            .HasPrecision(18, 2); 






        
        modelBuilder.Entity<RepairOrder>()
            .HasKey(ro => ro.Id);

        modelBuilder.Entity<RepairOrder>()
            .Property(ro => ro.UserId)
            .IsRequired();

        modelBuilder.Entity<RepairOrder>()
            .Property(ro => ro.CarId)
            .IsRequired();

        modelBuilder.Entity<RepairOrder>()
            .Property(ro => ro.ServiceType)
            .IsRequired();

        modelBuilder.Entity<RepairOrder>()
            .Property(ro => ro.OrderDate)
            .IsRequired();

        modelBuilder.Entity<RepairOrder>()
            .Property(ro => ro.ServiceStatus)
            .IsRequired();





        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Surname)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.EmailVerified)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}