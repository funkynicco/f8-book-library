using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using CarRentals.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    [Area("Default")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}