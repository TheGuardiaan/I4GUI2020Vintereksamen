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
    public class Seed_Guest
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //if (context.Guests.Any())
                //{
                //    return;
                //}

                string[] firstNames = new string[] 
                {
                    "Helena", "Jasmine", "Phoebe", "Aysha", "abraham", "Madeleine", "Christina",
                    "Melissa", "Marie", "Tamara", "Freya", "Robin", "Heather", "Lacey",
                    "Anais", "Lauren", "Jamie", "Millicent", "Bertha", "Aliya", "Kian",
                    "Aaliyah", "Aminah", "Kaitlin", "abby", "Iqra", "Fannie", "Anastasia",
                    "Paige", "Lottie", "Eve", "Caroline", "Carys", "Natalie", "Anna",
                    "Sam", "Kelly", "Elle", "abby", "Scarlet", "Rose", "Hannah",
                    "Alfie", "Tianna", "Amelia", "Ellis", "Grace", "Darcie", "Elsa",
                    "Sadie", "Mason", "Pearl", "Frank", "Steen", "Henrik", "Jonny"
                };
                string[] lastNames = new string[] {
                    "Riley", "Chapman", "Arnold", "Luna", "Kennedy", "Briggs",
                    "Reyes", "Garner", "Peters", "Henry", "Tyler", "Burton",
                    "Faulkner", "Williams", "Bernard", "Hamilton", "Mcfarlane", "Brady",
                    "Munoz", "Griffiths", "Martin", "Owens", "Delgado", "Graham",
                    "Welch", "Field", "Jenkins", "Carter", "Mitchell", "Dunn",
                    "Alvarez", "Espinoza", "Romero", "Donaldson", "Payne", "Watkins"
                };

                Random rand = new Random(20140);
                int guest = 35;

               
                for (int i = 0; i < guest; i++)
                {
                    string f_Name = firstNames[rand.Next(0, firstNames.Length - 1)];
                    string l_Name = lastNames[rand.Next(0, lastNames.Length - 1)];
                    string fullname = f_Name + " " + l_Name;

                    int chechInday = rand.Next(0, 11);
                    int noAdults = rand.Next(1, 6);
                    int noChildren = rand.Next(0, 4);

                    try
                    {

                        Guest findName= context.Guests.FirstOrDefault(x => x.FullName == fullname);

                        if (findName != null)
                        {
                            break;
                        }



                        Room findRoom = context.Rooms.Where(x => !x.RoomStatus).FirstOrDefault();

                        if (findRoom == null)
                        {
                            break;
                        }

                        

                        Guest newGuest = new Guest
                        {
                            FirstName = f_Name,
                            LastName = l_Name,
                            FullName = fullname,
                            PhoneNumber = "",
                            Email = f_Name + l_Name + "@" + guest + "mail.com",
                            Address = f_Name + "Street " + guest,
                            //Reserve = DateTime.Now.AddDays(chechInday + 1).Date,
                            Reserve = DateTime.Now.Date,
                            NoAdults = noAdults,
                            NoChildren = noChildren,
                            RoomId = findRoom.RoomId
                        };


                        context.Guests.Add(newGuest);

                        findRoom.RoomStatus = true;
                        context.Rooms.Update(findRoom);
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
