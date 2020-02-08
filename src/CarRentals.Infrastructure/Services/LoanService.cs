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
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarLoan>> GetAllCarLoans()
        {
            return await _context.CarLoans
                .Include(x => x.Car)
                .Include(a => a.Car.Details)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<CarLoan> CreateLoan(User user, Car car)
        {
            var loan = new CarLoan() { User = user, Car = car };
            _context.Add(loan);
            await _context.SaveChangesAsync();

            return loan;
        }
        

    }
}
