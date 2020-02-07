using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
 
        public HomeController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            var claims = new List<object>();
            foreach(var claim in User.Claims)
            {
                claims.Add(new
                {
                    claim.Issuer,
                    claim.Value
                });
            }

            return Json(claims);

            //return Json(_carService.GetCars());
        }
    }
}