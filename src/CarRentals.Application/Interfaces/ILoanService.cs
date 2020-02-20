using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Application.Interfaces
{
    public interface ILoanService
    {
        Task<Loan> CreateLoan(User user, Car car, DateTime loanUntil);

        Task<bool> IsCarLoaned(int carId);

        Task<IEnumerable<Loan>> GetCarLoans(int userId);

        Task<IEnumerable<Loan>> GetCarLoans();

        Task<Loan> GetCarLoan(int loan_id);

        Task<bool> ReturnCar(int id);
    }
}
