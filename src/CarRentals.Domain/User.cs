﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }

        public string SSN { get; set; }

        public string Role { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
    }
}
