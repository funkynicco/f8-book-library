using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Security
{
    public static class Policies
    {
        [PolicyRoles(Roles.Admin, Roles.Supervisor)]
        public const string AdminArea = nameof(AdminArea);

        [PolicyRoles(Roles.Admin)]
        public const string CreateCar = nameof(CreateCar);

        [PolicyRoles(Roles.Admin, Roles.Supervisor)]
        public const string ViewAllLoans = nameof(ViewAllLoans);

        [PolicyRoles(Roles.Admin, Roles.Supervisor)]
        public const string ViewUsers = nameof(ViewUsers);
    }
}
