using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly ILoanService _loanService;

        public CarsController(ICarService carService, ILoanService loanService)
        {
            _carService = carService;
            _loanService = loanService;
        }

        public IActionResult Index()
        {
            return Json(_loanService.GetAllCarLoans());
        }
    }
}