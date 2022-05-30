﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VenceParkingGarage.Infrastructure.Persistence;

namespace VenceParkingGarage.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220530100134_SeedInitialData2")]
    partial class SeedInitialData2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VenceParkingGarage.Core.Domain.Entities.ParkingLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkingLevels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Level = 1
                        },
                        new
                        {
                            Id = 2,
                            Level = 2
                        });
                });

            modelBuilder.Entity("VenceParkingGarage.Core.Domain.Entities.ParkingSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("ParkingLevelId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLevelId");

                    b.ToTable("ParkingSlots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = 1,
                            ParkingLevelId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Number = 2,
                            ParkingLevelId = 1,
                            Type = 2
                        });
                });

            modelBuilder.Entity("VenceParkingGarage.Core.Domain.Entities.ParkingSlotVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CurrentlyParked")
                        .HasColumnType("bit");

                    b.Property<int>("ParkingSlotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSlotId");

                    b.ToTable("ParkingSlotVehicles");
                });

            modelBuilder.Entity("VenceParkingGarage.Core.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("RequiredParkingSpace")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Toyota",
                            Color = "Red",
                            LicensePlate = "A-123",
                            RequiredParkingSpace = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Honda",
                            Color = "White",
                            LicensePlate = "A-456",
                            RequiredParkingSpace = 0,
                            Type = 2
                        });
                });

            modelBuilder.Entity("VenceParkingGarage.Core.Domain.Entities.ParkingSlot", b =>
                {
                    b.HasOne("VenceParkingGarage.Core.Domain.Entities.ParkingLevel", null)
                        .WithMany("ParkingSlots")
                        .HasForeignKey("ParkingLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VenceParkingGarage.Core.Domain.Entities.ParkingSlotVehicle", b =>
                {
                    b.HasOne("VenceParkingGarage.Core.Domain.Entities.ParkingSlot", null)
                        .WithMany("ParkingSlotVehicles")
                        .HasForeignKey("ParkingSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("VenceParkingGarage.Core.Domain.Entities.ParkedVehicleInfo", "ParkedVehicle", b1 =>
                        {
                            b1.Property<int>("ParkingSlotVehicleId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("LicensePlate")
                                .IsRequired()
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.Property<DateTime>("ParkedTime")
                                .HasColumnType("datetime2");

                            b1.Property<int>("VehicleId")
                                .HasColumnType("int");

                            b1.HasKey("ParkingSlotVehicleId");

                            b1.ToTable("ParkingSlotVehicles");

                            b1.WithOwner()
                                .HasForeignKey("ParkingSlotVehicleId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
