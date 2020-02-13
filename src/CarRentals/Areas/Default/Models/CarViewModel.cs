using CarRentals.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Areas.Default.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }

        public CarDetails Details { get; set; }

        public int Mileage { get; set; }

        public string RegistrationNumber { get; set; }

        public int CostPerDay { get; set; }
    }
}
