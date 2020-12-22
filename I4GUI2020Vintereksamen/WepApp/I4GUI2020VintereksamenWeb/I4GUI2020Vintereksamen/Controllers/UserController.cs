 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I4GUI2020Vintereksamen.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Results()
        {
            return View();
        }


        public IActionResult Section()
        {
            return View();
        }
    }
}
