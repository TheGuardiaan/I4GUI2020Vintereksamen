using I4GUI2020Vintereksamen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace I4GUI2020Vintereksamen.Data
{
    public class UserAdd
    {
        public async static void SeedUsers(UserManager<ApplicationUser> userManager, ILogger log)
        {

            const string Password = "123";
            DateTime dob = DateTime.Now;

            if (userManager.FindByNameAsync("Admin@localhost").Result == null)
            {
                log.LogWarning("Seeding the admin user");
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "Admin@localhost",
                    FirstName = "Marek",
                    LastName = "Dowling"
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("admin", "Yes"));
                }
            }



        }
    }
}

