using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Areas.Admin.Models
{
    public class CreateCarViewModel
    {
        [Required]
        public string Make { get; set; }

        [Range(1990, 2021)]
        public int Year { get; set; }

        [Range(1, 365)]
        public int MaxRentDays { get; set; }

        [Range(0, 999999)]
        public int Mileage { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string RegistrationNumber { get; set; }

        [Required]
        [Range(1, 999999)]
        public int CostPerDay { get; set; }
    }
}
