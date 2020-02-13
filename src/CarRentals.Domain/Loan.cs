using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Domain
{
    public class Loan
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }
        
        public int CarId { get; set; }
        
        public Car Car { get; set; }
        
        public DateTime LoanStart { get; set; }
        
        public DateTime LoanEnd { get; set; }

        public DateTime? CarReturned { get; set; }
    }
}
