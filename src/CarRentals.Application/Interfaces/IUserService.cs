using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);
    }
}
