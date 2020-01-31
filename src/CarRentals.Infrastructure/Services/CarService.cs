﻿using CarRentals.Application.Interfaces;
using CarRentals.Domain;
using CarRentals.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars;
        }

        public void AddCar(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
        }
    }
}