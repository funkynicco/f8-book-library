using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Security
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class PolicyRolesAttribute : Attribute
    {
        public string[] Roles { get; set; }

        public PolicyRolesAttribute(params string[] roles)
        {
            Roles = roles;
        }
    }
}
