using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentals.Application.Interfaces;
using CarRentals.Areas.Admin.Models;
using CarRentals.Domain;
using CarRentals.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Policy = Policies.AdminArea)]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = Policies.CreateCar)]
        public IActionResult CreateCar()
        {
            return View();
        }

        [Authorize(Policy = Policies.CreateCar)]
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var carDetails = _mapper.Map<CarDetails>(model);
            var car = _mapper.Map<Car>(model);

            await _carService.AddCarAndDetails(car, carDetails);
            return LocalRedirect("/cars");
        }
    }
}