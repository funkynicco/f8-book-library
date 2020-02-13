using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Areas.Default.Models
{
    public class CarLoanModel
    {
        public CarViewModel Car { get; set; }

        [Required]
        [RegularExpression(@"^\d+-\d+-\d+$")]
        public string LoanUntil { get; set; }
    }
}
