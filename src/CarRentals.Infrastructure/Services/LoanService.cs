using CarRentals.Application.Interfaces;
using CarRentals.Domain;
using CarRentals.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Loan>> GetCarLoans(int userId)
        {
            return await _context.Loans
                .Where(x => x.UserId == userId)
                .Include(x => x.Car)
                .Include(a => a.Car.Details)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetCarLoans()
        {
            return await _context.Loans
                .Include(x => x.Car)
                .Include(a => a.Car.Details)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Loan> CreateLoan(User user, Car car, DateTime loanUntil)
        {
            var loan = new Loan()
            {
                User = user,
                Car = car,
                LoanStart = DateTime.UtcNow,
                LoanEnd = loanUntil
            };

            _context.Add(loan);
            await _context.SaveChangesAsync();

            var userLoan = new UserLoan() { UserId = user.Id, LoanId = loan.Id };
            _context.UserLoans.Add(userLoan);

            await _context.SaveChangesAsync();

            return loan;
        }
    }
}
