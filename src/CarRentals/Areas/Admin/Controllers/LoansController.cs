using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using CarRentals.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = Policies.AdminArea)]
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [Authorize(Policy = Policies.ViewAllLoans)]
        [Route("/{area}/{controller}/show-all")]
        public async Task<IActionResult> ShowAll()
        {
            var loans = await _loanService.GetCarLoans();
            return View(loans);
        }
    }
}