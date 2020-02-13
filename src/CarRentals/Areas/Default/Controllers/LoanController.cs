using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Areas.Default.Controllers
{
    [Area("Default")]
    [Authorize]
    public class LoanController : Controller
    {
        [Route("/{controller}/{id}")]
        public IActionResult Index(int id)
        {
            return Content("id " + id);
        }
    }
}