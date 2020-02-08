using CarRentals.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarDetails> CarDetails { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CarLoan> CarLoans { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfiguerUser(modelBuilder);
            ConfigureCar(modelBuilder);
            ConfiguerCarLoan(modelBuilder);
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfiguerUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.SSN).IsRequired();
        }

        private static void ConfiguerCarLoan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarLoan>().HasOne(x => x.Car);
            modelBuilder.Entity<CarLoan>().HasOne(x => x.User);
            
        }

        private static void ConfigureCar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetails>().Property(x => x.Model).HasMaxLength(16);
            modelBuilder.Entity<Car>().Property(x => x.RegistrationNumber).HasMaxLength(6);
            modelBuilder.Entity<Car>().Property(x => x.RegistrationNumber).IsRequired();

            modelBuilder.Entity<Car>()
                .HasOne(x => x.Details);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetails>().HasData(
                new CarDetails() { Id = 1, Model = "BMW" },
                new CarDetails() { Id = 2, Model = "Audi" },
                new CarDetails() { Id = 3, Model = "Volvo" },
                new CarDetails() { Id = 4, Model = "SAAB" }
                );

            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 99, DetailsId = 1, Mileage = 134, RegistrationNumber = "ABC123" },
                new Car() { Id = 2, DetailsId = 2, Mileage = 600, RegistrationNumber = "BOA123" },
                new Car() { Id = 3, DetailsId = 3, Mileage = 642, RegistrationNumber = "KIA499" },
                new Car() { Id = 4, DetailsId = 4, Mileage = 1500, RegistrationNumber = "PYA635" }
                );
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 4, FirstName = "TestUser", LastName = "UserLastName", SSN = "99012323" }
                );

            // CarDetails is the make and model of a car, not a specific car
            // Car is the actual car with registration number and mileage
            // CarLoan binds a user to a Car
        }
    }
}
