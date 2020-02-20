using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    [Area("Default")]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var make = Request.Query["make"].ToString();

            var max_cost = int.MaxValue;
            if (int.TryParse(Request.Query["max_cost"], out int cost))
                max_cost = cost;

            var cars = await _carService.GetAvailableCars();
            cars = cars.Where(a =>
                a.Details.Make.Contains(make, StringComparison.InvariantCultureIgnoreCase) &&
                a.CostPerDay <= max_cost);

            return View(cars);
        }
    }
}