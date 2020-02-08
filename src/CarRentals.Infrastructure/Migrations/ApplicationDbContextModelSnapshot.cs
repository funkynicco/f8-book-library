﻿// <auto-generated />
using System;
using CarRentals.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentals.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentals.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DetailsId")
                        .HasColumnType("int");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.HasIndex("DetailsId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 99,
                            DetailsId = 1,
                            Mileage = 134,
                            RegistrationNumber = "ABC123"
                        },
                        new
                        {
                            Id = 2,
                            DetailsId = 2,
                            Mileage = 600,
                            RegistrationNumber = "BOA123"
                        },
                        new
                        {
                            Id = 3,
                            DetailsId = 3,
                            Mileage = 642,
                            RegistrationNumber = "KIA499"
                        },
                        new
                        {
                            Id = 4,
                            DetailsId = 4,
                            Mileage = 1500,
                            RegistrationNumber = "PYA635"
                        });
                });

            modelBuilder.Entity("CarRentals.Domain.CarDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("CarDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Model = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Model = "Audi"
                        },
                        new
                        {
                            Id = 3,
                            Model = "Volvo"
                        },
                        new
                        {
                            Id = 4,
                            Model = "SAAB"
                        });
                });

            modelBuilder.Entity("CarRentals.Domain.CarLoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoanStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("CarLoans");
                });

            modelBuilder.Entity("CarRentals.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16)
                        .HasDefaultValue("User");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "heppe.yt@gmail.com",
                            FirstName = "Hampus",
                            LastName = "Precenth",
                            Role = "Admin",
                            SSN = "830909-7825"
                        },
                        new
                        {
                            Id = 2,
                            Email = "albin8686@gmail.com",
                            FirstName = "Albin",
                            LastName = "Arab",
                            Role = "Admin",
                            SSN = "940204-2395"
                        },
                        new
                        {
                            Id = 3,
                            Email = "funkynicco@gmail.com",
                            FirstName = "Niklas",
                            LastName = "Landberg",
                            Role = "Admin",
                            SSN = "940414-4694"
                        },
                        new
                        {
                            Id = 4,
                            Email = "niklas.h.landberg@gmail.com",
                            FirstName = "Niklas",
                            LastName = "(Test User)",
                            Role = "User",
                            SSN = "112233-4050"
                        });
                });

            modelBuilder.Entity("CarRentals.Domain.Car", b =>
                {
                    b.HasOne("CarRentals.Domain.CarDetails", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentals.Domain.CarLoan", b =>
                {
                    b.HasOne("CarRentals.Domain.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentals.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
