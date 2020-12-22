using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheHotel.Models;

namespace TheHotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                Seed_RoomA.Initialize(services);
                Seed_RoomB.Initialize(services);
                Seed_RoomC.Initialize(services);
                Seed_Guest.Initialize(services);
                Seed_CheckInd.Initialize(services);


                //try
                //{
                //    Seed_Room.Initialize(services);
                //} catch (Exception)
                //{

                //    throw;
                //}

            }

                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
