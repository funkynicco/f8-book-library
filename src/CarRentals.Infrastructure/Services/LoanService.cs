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
            var loans = new List<Loan>();

            var userLoans = await _context.UserLoans
                .Where(x => x.UserId == userId)
                .Include(x => x.Loan)
                .Include(x => x.Loan.Car)
                .Include(x => x.Loan.Car.Details)
                .ToListAsync();

            userLoans.ForEach(userLoan => loans.Add(userLoan.Loan));

            return loans;
        }

        public async Task<IEnumerable<Loan>> GetCarLoans()
        {
            var loans = new List<Loan>();

            var userLoans = await _context.UserLoans
                .Include(x => x.Loan)
                .Include(x => x.Loan.Car)
                .Include(x => x.Loan.Car.Details)
                .ToListAsync();

            userLoans.ForEach(userLoan => loans.Add(userLoan.Loan));

            return loans;
        }

        public async Task<bool> IsCarLoaned(int carId)
        {
            return await _context.UserLoans
                .Include(x => x.Loan)
                .AnyAsync(a => a.Loan.CarId == carId);
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

        public async Task<Loan> GetCarLoan(int id)
        {
            return await _context.Loans
                .Include(x => x.Car)
                .Include(a => a.Car.Details)
                .Include(x => x.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> ReturnCar(int loanId)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(a => a.Id == loanId);
            if (loan == null)
                return false;

            if (loan.CarReturned.HasValue)
                return false;

            var userLoan = await _context.UserLoans.FirstOrDefaultAsync(a => a.LoanId == loanId);
            if (userLoan == null)
                return false;

            loan.CarReturned = DateTime.UtcNow;

            _context.UserLoans.Remove(userLoan);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
