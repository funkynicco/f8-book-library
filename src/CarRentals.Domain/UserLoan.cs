using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Domain
{
    public class UserLoan
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int LoanId { get; set; }

        public Loan Loan { get; set; }
    }
}
