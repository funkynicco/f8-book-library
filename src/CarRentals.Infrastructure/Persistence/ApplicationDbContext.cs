using CarRentals.Domain;
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

        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCar(modelBuilder);
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureCar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetails>().Property(x => x.Model).HasMaxLength(16);
            modelBuilder.Entity<Car>().Property(x => x.RegistrationNumber).HasMaxLength(6);

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

            // CarDetails is the make and model of a car, not a specific car
            // Car is the actual car with registration number and mileage
            // CarLoan binds a user to a Car
        }
    }
}
