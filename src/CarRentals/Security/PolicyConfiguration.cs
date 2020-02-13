using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarRentals.Security
{
    public class PolicyConfiguration
    {
        private readonly AuthorizationOptions _options;

        public PolicyConfiguration(AuthorizationOptions options)
        {
            _options = options;
        }

        public void ConfigurePolicies()
        {
            AddPolicyRolesByAttributes();

            // ability to add specific policies here, like below:
            //AddPolicy(Policies.CreateCar, Roles.Admin); // creating a car is the CreateCar policy, which requires the user to have admin role
        }

        #region Helper methods
        private void AddPolicy(string policyName, params string[] roles)
            => _options.AddPolicy(policyName, policy => policy.RequireRole(roles));

        private void AddPolicyRolesByAttributes()
        {
            foreach (var field in typeof(Policies).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var policyRolesAttribute = field.GetCustomAttribute<PolicyRolesAttribute>();
                if (policyRolesAttribute == null)
                    continue;

                var value = (string)field.GetValue(null);
                //policyRolesAttribute.Roles
                AddPolicy(value, policyRolesAttribute.Roles);
            }
        }
        #endregion
    }
}
