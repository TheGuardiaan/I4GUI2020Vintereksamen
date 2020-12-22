using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHotel.Data;
using TheHotel.Data.Entity;

namespace TheHotel.Models
{
    public class Seed_CheckInd
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                Random rand = new Random(20140);
                int guest = 7;

               
                for (int i = 1; i < guest; i++)
                {


                    FoodCheckIn findGuest = context.FoodCheckIns.Where(x => x.GuestId == i).FirstOrDefault();

                    if (findGuest != null)
                    {
                        break;
                    }


                    try
                    {                        

                        FoodCheckIn newGuest = new FoodCheckIn
                        {
                            CheckInDate = DateTime.Now,
                            GuestId = i,     


                        };

                        context.FoodCheckIns.Add(newGuest);

                        context.SaveChanges();

                    } catch (Exception)
                    {

                        throw;
                    }
                    
                }


               

            }
        }
    }
}
