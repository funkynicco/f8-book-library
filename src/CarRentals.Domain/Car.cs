using System;

namespace CarRentals.Domain
{
    public class Car
    {
        public int Id { get; set; }

        public int DetailsId { get; set; }

        public CarDetails Details { get; set; }

        public int Mileage { get; set; }

        public string RegistrationNumber { get; set; }
    }
}
