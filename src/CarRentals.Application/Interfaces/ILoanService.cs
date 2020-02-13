using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Application.Interfaces
{
    public interface ILoanService
    {
        public Task<Loan> CreateLoan(User user, Car car, DateTime loanUntil);

        public Task<IEnumerable<Loan>> GetAllCarLoans();

    }
}
