using CarRentals.Application.Interfaces;
using CarRentals.Domain;
using CarRentals.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car> GetCar(int id)
        {
            return await _context.Cars
                .Include(x => x.Details)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _context.Cars
                .Include(x => x.Details)
                .ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAvailableCars()
        {
            var cars = await _context.Cars
               .Include(x => x.Details)
               .ToListAsync();

            var userLoans = await _context.UserLoans
                .Include(x => x.Loan)
                .ToListAsync();

            foreach (var loan in userLoans)
            {
                cars.Remove(loan.Loan.Car);
            }

            return cars;
        }

        public async Task AddCar(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task AddCarDetails(CarDetails carDetails)
        {
            _context.CarDetails.Add(carDetails);
            await _context.SaveChangesAsync();
        }

        public async Task AddCarAndDetails(Car car, CarDetails details)
        {
            _context.CarDetails.Add(details);
            await _context.SaveChangesAsync();
            
            car.Details = details;
        
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }
    }
}
