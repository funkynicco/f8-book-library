using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Application.Interfaces
{
    public interface ILoanService
    {
        public CarLoan CreateLoan(User _user, Car _car);

        public IEnumerable<CarLoan> GetAllCarLoans();

    }
}
