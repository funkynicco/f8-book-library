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

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _context.Cars
                .Include(x => x.Details)
                .ToListAsync();
        }

        public async Task AddCar(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
        }
    }
}
