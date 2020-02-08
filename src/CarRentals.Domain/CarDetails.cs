using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Domain
{
    public class CarDetails
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int MaxRentDays { get; set; }
    }
}
