using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheHotel.Models;

namespace TheHotel.Controllers
{
    //[Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            if (User.HasClaim("admin", "Yes"))
                return RedirectToAction("Index", "Employee");
            if (User.HasClaim("kok", "Yes"))
                return RedirectToAction("Index", "Kitchen");
            if (User.HasClaim("tjener", "Yes"))
                return RedirectToAction("Index", "FoodCheckIn");
            if (User.HasClaim("receptionist", "Yes"))
                return RedirectToAction("Index", "Guest");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
