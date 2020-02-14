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
            return View(await _carService.GetAvailableCars());
        }
    }
}