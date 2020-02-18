using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Areas.Admin.Models
{
    public class CreateCarDetailsViewModel
    {
        [Required]
        public string Make { get; set; }

        [Range(1990, 2021)]
        public int Year { get; set; }

        [Range(1, 365)]
        public int MaxRentDays { get; set; }
    }
}