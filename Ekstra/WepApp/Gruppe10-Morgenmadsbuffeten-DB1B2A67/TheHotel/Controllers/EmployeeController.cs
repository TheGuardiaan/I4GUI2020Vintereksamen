using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheHotel.Data;
using TheHotel.Data.Entity;
using TheHotel.Models;

namespace TheHotel.Controllers
{

    [Authorize(Policy = "isAdmin")]
    public class EmployeeController : Controller
    {
        

        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index(int p = 1)
        {

            int countServing = await _context.Users.Where(x => x.PositionName == "tjener").CountAsync(x => x.FirstName != "");
            ViewData["countServing"] = countServing;


            int countChef = await _context.Users.Where(x => x.PositionName == "kok").CountAsync(x => x.FirstName != "");
            ViewData["countChef"] = countChef;

            int sumReceptionist = await _context.Users.Where(x => x.PositionName == "receptionist").CountAsync(x => x.FirstName != "");
            ViewData["sumReceptionist"] = sumReceptionist;

            int pageSize = 15;
            var users = _context.Users.OrderByDescending(x => x.Id)
                                                .Skip((p - 1) * pageSize)
                                                
                                                .Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Users.Count() / pageSize);

            return View(await users.ToListAsync());

        }

       // GET: Employee/Create
        public IActionResult Create()
        {
            return Redirect("~/Identity/Account/Register");
        }

        
        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ApplicationUser user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id.ToString());

            if (user == null)
            {
                //TempData["Error"] = "The page dose not exist!";
            } else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Denne ansat er blevet Fyret!";
            }

            return RedirectToAction("Index");
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id.ToString());
        }
    }
}
