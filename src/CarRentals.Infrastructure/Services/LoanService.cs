using CarRentals.Application.Interfaces;
using CarRentals.Domain;
using CarRentals.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarLoan> GetAllCarLoans()
        {
            return _context.CarLoans.Include(x => x.car).Include(a => a.car.Details).Include(b => b.user);
        }
        public CarLoan CreateLoan(User _user, Car _car)
        {
            var loan = new CarLoan() { user = _user, car = _car };
            _context.Add(loan);
            _context.SaveChanges();

            return loan;
        }
        

    }
}
