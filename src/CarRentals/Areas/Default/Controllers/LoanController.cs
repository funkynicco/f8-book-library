using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CarRentals.Application.Interfaces;
using CarRentals.Areas.Default.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Areas.Default.Controllers
{
    [Area("Default")]
    [Authorize]
    public class LoanController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly ILoanService _loanService;

        public LoanController(IMapper mapper, IUserService userService, ICarService carService, ILoanService loanService)
        {
            _mapper = mapper;
            _userService = userService;
            _carService = carService;
            _loanService = loanService;
        }

        [Route("/{controller}/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var car = await _carService.GetCar(id);
            if (car == null)
                return NotFound();

            var now = DateTime.Now;

            return View(new CarLoanModel()
            {
                Car = _mapper.Map<CarViewModel>(car),
                LoanUntil = $"{now.Year:0000}-{now.Month:00}-{now.Day:00}"
            });
        }

        [Route("/{controller}/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(int id, CarLoanModel model)
        {
            var car = await _carService.GetCar(id);

            // map car to CarViewModel
            model.Car = _mapper.Map<CarViewModel>(car);

            if (!ModelState.IsValid)
                return View(model);

            // get logged in user email
            var email = User.Claims.Where(a => a.Type == ClaimTypes.Email).FirstOrDefault().Value;

            // fetch the user by email
            var user = await _userService.GetUserByEmail(email);

            // parse LoanUntil and set the type to UTC date
            var loanUntil = DateTime.SpecifyKind(DateTime.Parse(model.LoanUntil), DateTimeKind.Utc);

            // create loan
            await _loanService.CreateLoan(user, car, loanUntil);

            // redirect
            return LocalRedirect("/cars");
        }

        public async Task<IActionResult> Return(int id)
        {

            return LocalRedirect("/cars");
        }
    }
}