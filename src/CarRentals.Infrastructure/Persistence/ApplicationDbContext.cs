﻿using CarRentals.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRentals.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarDetails> CarDetails { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<UserLoan> UserLoans { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfiguerUser(modelBuilder);
            ConfigureCarDetails(modelBuilder);
            ConfigureCar(modelBuilder);
            ConfiguerCarLoan(modelBuilder);
            ConfigureUserLoan(modelBuilder);
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfiguerUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<User>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<User>().Property(x => x.SSN)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<User>().Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            // set the email to have unique constraint so no duplicates happens
            modelBuilder.Entity<User>().HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>().Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValue("User");
        }

        private static void ConfiguerCarLoan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasOne(x => x.Car);
            modelBuilder.Entity<Loan>().HasOne(x => x.User);
        }

        private static void ConfigureCarDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetails>().Property(x => x.Make)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<CarDetails>().Property(x => x.MaxRentDays)
                .IsRequired()
                .HasDefaultValue(14);
        }

        private static void ConfigureCar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(x => x.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Car>()
                .HasOne(x => x.Details);
        }

        private static void ConfigureUserLoan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLoan>().Property(x => x.UserId)
                .IsRequired();

            modelBuilder.Entity<UserLoan>().Property(x => x.LoanId)
                .IsRequired();


            modelBuilder.Entity<UserLoan>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserLoan>()
                .HasOne(x => x.Loan)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetails>().HasData(
                new CarDetails() { Id = 1, Make = "BMW 335D", Year = 2010, MaxRentDays = 14 },
                new CarDetails() { Id = 2, Make = "Audi A6 Quattro", Year = 2014, MaxRentDays = 14 },
                new CarDetails() { Id = 3, Make = "Volvo V70", Year = 2012, MaxRentDays = 14 },
                new CarDetails() { Id = 4, Make = "SAAB 9-3", Year = 2006, MaxRentDays = 14 }
                );

            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 99, DetailsId = 1, Mileage = 134, RegistrationNumber = "ABC123", CostPerDay = 2000 },
                new Car() { Id = 2, DetailsId = 2, Mileage = 600, RegistrationNumber = "BOA123", CostPerDay = 2500 },
                new Car() { Id = 3, DetailsId = 3, Mileage = 642, RegistrationNumber = "KIA499", CostPerDay = 2200 },
                new Car() { Id = 4, DetailsId = 4, Mileage = 1500, RegistrationNumber = "PYA635", CostPerDay = 900 }
                );

            modelBuilder.Entity<User>().HasData(
                // admin accounts
                new User() { Id = 1, FirstName = "Hampus", LastName = "Precenth", Email = "heppe.yt@gmail.com", SSN = "830909-7825", Role = "Admin" },   // personnummer för Astrid Rundgren
                new User() { Id = 2, FirstName = "Albin", LastName = "Arab", Email = "albin8686@gmail.com", SSN = "940204-2395", Role = "Admin" },      // personnummer för Sven-Erik Källström
                new User() { Id = 3, FirstName = "Niklas", LastName = "Landberg", Email = "funkynicco@gmail.com", SSN = "940414-4694", Role = "Admin" }, // personnummer för Noel Rapp

                // test regular users
                new User() { Id = 4, FirstName = "Niklas", LastName = "(Test User)", Email = "niklas.h.landberg@gmail.com", SSN = "112233-4050", Role = "User" }
                );
        }
    }
}
