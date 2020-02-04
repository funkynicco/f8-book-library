using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Domain
{
    public class CarLoan
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int CarId { get; set; }
        public Car car { get; set; }
        public int Id { get; set; }
        public int cost { get; set; }
        public DateTime LoanStart { get; set; }
        public DateTime LoanEnd { get; set; }

    }
}
