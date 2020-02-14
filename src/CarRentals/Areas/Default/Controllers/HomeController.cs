using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IUserService _userService;
        private readonly ILoanService _loanService;

        public HomeController(IUserService userService, ILoanService loanService)
        {
            _userService = userService;
            _loanService = loanService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/loans")]
        public async Task<IActionResult> Loans()
        {
            // get logged in user email
            var email = User.Claims.Where(a => a.Type == ClaimTypes.Email).FirstOrDefault().Value;

            // fetch the user by email
            var user = await _userService.GetUserByEmail(email);

            var loans = await _loanService.GetCarLoans(user.Id);

            return View(loans);
        }
    }
}