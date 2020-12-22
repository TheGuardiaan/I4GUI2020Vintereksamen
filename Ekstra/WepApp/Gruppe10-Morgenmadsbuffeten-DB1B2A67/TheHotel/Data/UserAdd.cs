using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TheHotel.Models;

namespace TheHotel.Data
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
                    PositionName = "admin",
                    FirstName = "Marek",
                    LastName = "Dowling",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("admin", "Yes"));
                    await userManager.AddClaimAsync(user, new Claim("kok", "Yes"));
                    await userManager.AddClaimAsync(user, new Claim("tjener", "Yes"));
                    await userManager.AddClaimAsync(user, new Claim("receptionist", "Yes"));
                }
            }

            if (userManager.FindByNameAsync("Kok@localhost").Result == null)
            {
                log.LogWarning("Seeding the kok user");
                var user = new ApplicationUser
                {
                    UserName = "kok",
                    Email = "Kok@localhost",
                    PositionName = "kok",
                    FirstName = "Eisa",
                    LastName = "Crawford",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("kok", "Yes"));
                }
            }

            if (userManager.FindByNameAsync("Tjener@localhost").Result == null)
            {
                log.LogWarning("Seeding the tjener user");
                var user = new ApplicationUser
                {
                    UserName = "tjener",
                    Email = "Tjener@localhost",
                    PositionName = "tjener",
                    FirstName = "Bobbie",
                    LastName = "Zimmerman",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("tjener", "Yes"));
                }
            }


            if (userManager.FindByNameAsync("Receptionist@localhost").Result == null)
            {
                log.LogWarning("Seeding the receptionist user");
                var user = new ApplicationUser
                {
                    UserName = "receptionist",
                    Email = "Receptionist@localhost",
                    PositionName = "receptionist",
                    FirstName = "Rowan",
                    LastName = "Rawlings",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("receptionist", "Yes"));
                }
            }




            if (userManager.FindByNameAsync("Kok1@localhost").Result == null)
            {
                log.LogWarning("Seeding the kok user");
                var user = new ApplicationUser
                {
                    UserName = "Largeparrot",
                    Email = "Kok1@localhost",
                    PositionName = "kok",
                    FirstName = "Cutthroat",
                    LastName = "Bill",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("kok", "Yes"));
                }
            }

            if (userManager.FindByNameAsync("Kok2@localhost").Result == null)
            {
                log.LogWarning("Seeding the kok user");
                var user = new ApplicationUser
                {
                    UserName = "DreadPirate",
                    Email = "Kok2@localhost",
                    PositionName = "kok",
                    FirstName = "Cap'n",
                    LastName = "Dreadful",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("kok", "Yes"));
                }
            }


            if (userManager.FindByNameAsync("Tjener1@localhost").Result == null)
            {
                log.LogWarning("Seeding the tjener user");
                var user = new ApplicationUser
                {
                    UserName = "FirstJohn",
                    Email = "Tjener1@localhost",
                    PositionName = "tjener",
                    FirstName = "Mate",
                    LastName = "Pete",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("tjener", "Yes"));
                }
            }


            if (userManager.FindByNameAsync("Receptionist1@localhost").Result == null)
            {
                log.LogWarning("Seeding the receptionist user");
                var user = new ApplicationUser
                {
                    UserName = "ThePirate",
                    Email = "Receptionist1@localhost",
                    PositionName = "receptionist",
                    FirstName = "Sir John",
                    LastName = "Long",
                    Dob = dob
                };
                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("receptionist", "Yes"));
                }
            }




        }
    }
}

