using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Areas.Admin.Models;
using CarRentals.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Areas.Admin.Controllers
{

    [Area("Admin")]
    //[Authorize(Policy = Policies.AdminArea)]
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Policy = Policies.CreateCarDetails)]
        public IActionResult CreateCarDetails()
        {
            return View();
        }

        //[Authorize(Policy = Policies.CreateCarDetails)]
        [HttpPost]
        public IActionResult CreateCarDetails(CreateCarDetailsViewModel model)
        {
            //[Bind("Model", "Year", "MaxRentDays")]
            return View(model);
        }
    }
}