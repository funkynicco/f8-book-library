using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Application.Interfaces
{
    public interface ILoanService
    {
        public Task<CarLoan> CreateLoan(User user, Car car);

        public Task<IEnumerable<CarLoan>> GetAllCarLoans();

    }
}
