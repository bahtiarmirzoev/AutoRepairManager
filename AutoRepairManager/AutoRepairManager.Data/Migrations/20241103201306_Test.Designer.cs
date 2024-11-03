﻿// <auto-generated />
using System;
using AutoRepairManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoRepairManager.Data.Migrations
{
    [DbContext(typeof(AutoRepairManagerDbContext))]
    [Migration("20241103201306_Test")]
    partial class Test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoRepairManager.Models.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("RepairOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RepairOrderId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.RepairHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("RepairDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("RepairHistories");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.RepairOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServiceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("RepairOrders");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AutoRepairManager.Models.ServiceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.Car", b =>
                {
                    b.HasOne("AutoRepairManager.Models.Models.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.Invoice", b =>
                {
                    b.HasOne("AutoRepairManager.Models.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoRepairManager.Models.Models.RepairOrder", "RepairOrder")
                        .WithMany("Invoices")
                        .HasForeignKey("RepairOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("RepairOrder");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.RepairHistory", b =>
                {
                    b.HasOne("AutoRepairManager.Models.Models.Car", "Car")
                        .WithMany("RepairHistory")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoRepairManager.Models.Models.Customer", null)
                        .WithMany("RepairHistory")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.RepairOrder", b =>
                {
                    b.HasOne("AutoRepairManager.Models.Models.Car", "Car")
                        .WithMany("RepairOrders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoRepairManager.Models.Models.Customer", "Customer")
                        .WithMany("RepairOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoRepairManager.Models.ServiceType", "ServiceType")
                        .WithMany("RepairOrders")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.Car", b =>
                {
                    b.Navigation("RepairHistory");

                    b.Navigation("RepairOrders");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.Customer", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Invoices");

                    b.Navigation("RepairHistory");

                    b.Navigation("RepairOrders");
                });

            modelBuilder.Entity("AutoRepairManager.Models.Models.RepairOrder", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("AutoRepairManager.Models.ServiceType", b =>
                {
                    b.Navigation("RepairOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
