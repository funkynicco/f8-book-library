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

        public async Task<IEnumerable<Loan>> GetAllCarLoans()
        {
            return await _context.Loans
                .Include(x => x.Car)
                .Include(a => a.Car.Details)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Loan> CreateLoan(User user, Car car)
        {
            var loan = new Loan() { User = user, Car = car };
            _context.Add(loan);
            await _context.SaveChangesAsync();

            return loan;
        }
        

    }
}
