using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Application.Interfaces
{
    public interface ICarService
    {
        Task<Car> GetCar(int id);

        Task<IEnumerable<Car>> GetCars();

        Task AddCar(Car car);

        Task<IEnumerable<Car>> GetAvailableCars();
    }
}
