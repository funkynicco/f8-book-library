using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Application.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetCars();
    }
}
