using I4GUI2020Vintereksamen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using I4GUI2020Vintereksamen.Models.DbModels;

namespace I4GUI2020Vintereksamen.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<I4GUI2020Vintereksamen.Models.DbModels.test> test { get; set; }
    }
}
