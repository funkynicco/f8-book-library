using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
    }
}