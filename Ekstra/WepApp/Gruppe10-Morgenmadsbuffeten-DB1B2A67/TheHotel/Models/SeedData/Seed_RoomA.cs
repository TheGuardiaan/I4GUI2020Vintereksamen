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
    public class Seed_RoomA
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                string[] prices = new string[] {"1000", "550", "2500"};
                string roomLetter = "A";

                Random rand = new Random(20140);
                int rooms = 35;


                for (int i = 0; i < rooms; i++)
                {
                    string price = prices[rand.Next(0, prices.Length - 1)];


                    string roomNr = roomLetter + i;
                    //int roomNr = rand.Next(0, rooms);                  

                    try
                    {
                        Room findRoom = context.Rooms.Where(x => x.RoomNr == roomNr).FirstOrDefault();

                        if (findRoom != null)
                        {
                            break;
                        }

                        Room newRoom = new Room
                        {
                            RoomNr = roomNr.ToString(),
                            Price = Int32.Parse(price),
                            RoomStatus = false
                        };


                        context.Rooms.Add(newRoom);
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