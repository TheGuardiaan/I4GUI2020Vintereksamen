using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheHotel.Data.Entity;
using TheHotel.Models;

namespace TheHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }




        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }



        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<FoodCheckIn> FoodCheckIns { get; set; }


    }
}
