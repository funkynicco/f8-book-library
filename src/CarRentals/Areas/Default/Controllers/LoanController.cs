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
            if (await _loanService.IsCarLoaned(id))
                return BadRequest();

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
            if (await _loanService.IsCarLoaned(id))
                return BadRequest();

            var car = await _carService.GetCar(id);

            // map car to CarViewModel
            model.Car = _mapper.Map<CarViewModel>(car);

            if (!ModelState.IsValid)
                return View(model);

            // parse LoanUntil and set the type to UTC date
            var loanUntil = DateTime.SpecifyKind(DateTime.Parse(model.LoanUntil), DateTimeKind.Utc);
            if (loanUntil < DateTime.UtcNow) // check that the loan end date is in the future, at least 1 day
            {
                ModelState.AddModelError("LoanUntil", "Date must be in the future.");
                return View(model);
            }

            var user = await HttpContext.GetCurrentUser(_userService);

            // create loan
            await _loanService.CreateLoan(user, car, loanUntil);

            // redirect
            return LocalRedirect("/cars");
        }

        [Route("/loans")]
        public async Task<IActionResult> Loans()
        {
            var user = await HttpContext.GetCurrentUser(_userService);

            var loans = await _loanService.GetCarLoans(user.Id);

            return View(loans);
        }

        public async Task<IActionResult> Return(int id) // /loan/return/2
        {
            var user = await HttpContext.GetCurrentUser(_userService);

            var loan = await _loanService.GetCarLoan(id);
            if (loan.UserId != user.Id)
                return BadRequest();

            var model = new ReturnCarViewModel()
            {
                Price = loan.Car.CostPerDay * loan.DaysLoaned,
                LoanId = id
            };
            return View(model);
        }

        [Route("/{controller}/return-confirm/{id}")]
        public async Task<IActionResult> ReturnConfirm(int id) // /loan/return-confirm/2
        {
            var user = await HttpContext.GetCurrentUser(_userService);
         
            var loan = await _loanService.GetCarLoan(id);
            if (loan.UserId != user.Id)
                return BadRequest();

            if (!await _loanService.ReturnCar(loan.Id))
                return BadRequest();

            return LocalRedirect("/cars");
        }
    }
}