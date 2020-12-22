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

namespace TheHotel.Controllers
{
    [Authorize(Policy = "isTjener")]
    public class FoodCheckInController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodCheckInController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: FoodCheckIn
        public async Task<IActionResult> Index(int? p, DateTime? date)
        {
            //var checkFoodCheckInId = await _context.FoodCheckIn.FirstOrDefaultAsync(x => x.FoodCheckInId == 0);
            
            int pages;

            if (p.HasValue)
                pages = (int)p;
            else
                pages = 1;

            ViewData["myDate"] = new SelectList(_context.Guests, "CheckOutDate");


            DateTime iDate;
            if (date.HasValue)
                iDate = (DateTime)date;
            else
                iDate = DateTime.Now.Date;
            ViewData["myDate"] = iDate;



            int checkInAdult = await _context.FoodCheckIns.Where(r => r.CheckInDate.Date == DateTime.Now.Date).SumAsync(x => x.Guest.NoAdults);
            ViewData["checkInAdult"] = checkInAdult;

            int checkInChildren = await _context.FoodCheckIns.Where(r => r.CheckInDate.Date == DateTime.Now.Date).SumAsync(x => x.Guest.NoChildren);
            ViewData["checkInChildren"] = checkInChildren;

            int checkInCount = checkInAdult + checkInChildren;
            ViewData["checkInCount"] = checkInCount;



            int notCheckInAdult = await _context.Guests.Where(r => r.Reserve.Date == Convert.ToDateTime(iDate)).SumAsync(x => x.NoAdults);
            ViewData["notCheckInAdult"] = notCheckInAdult - checkInAdult;

            int notCheckInChildren = await _context.Guests.Where(r => r.Reserve.Date == Convert.ToDateTime(iDate)).SumAsync(x => x.NoChildren);
            ViewData["notCheckInChildren"] = notCheckInChildren - checkInChildren;

            int notCheckInCount = notCheckInAdult + notCheckInChildren;
            ViewData["notCheckInCount"] = notCheckInCount - checkInCount;


            int pageSize = 15;
            var foodCheckIns = _context.FoodCheckIns.OrderByDescending(x => x.FoodCheckInId)
                                                .Skip((pages - 1) * pageSize)
                                                .Include(f => f.Guest)
                                                .Include(g => g.Room)
                                                .Take(pageSize);


            ViewBag.PageNumber = pages;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.FoodCheckIns.Count() / pageSize);

            return View(await foodCheckIns.Include(f => f.Guest).ToListAsync());

            //return View(await _context.Employees.ToListAsync());
        }



        // GET: FoodCheckIn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCheckIn = await _context.FoodCheckIns
                .Include(f => f.Guest)
                .Include(f => f.Room)
                .FirstOrDefaultAsync(m => m.FoodCheckInId == id);
            if (foodCheckIn == null)
            {
                return NotFound();
            }

            return View(foodCheckIn);
        }

        // GET: FoodCheckIn/Create
        public IActionResult Create()
        {

            ViewData["RoomId"] = new SelectList(_context.Rooms.Where(x => x.RoomStatus == true), "RoomId", "RoomNr");

            //ViewBag["Name"]  = _context.Guests.Where(x => x.RoomId;




            ViewData["GuestId"] = new SelectList(_context.Guests
                                                .Include(x => x.Room)
                                                .Where(x => x.FoodCheckIns.Count < 1 && x.Reserve == DateTime.Now.Date), "GuestId", "FullName", "RoomId");





            return View();
        }

        // POST: FoodCheckIn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodCheckIn foodCheckIn)
        {
            if (ModelState.IsValid)
            {
                var check = await _context.FoodCheckIns.FirstOrDefaultAsync(x => x.GuestId == foodCheckIn.GuestId);
                if (check != null)
                {
                    ModelState.AddModelError("", "This Guest Has Already Been Checked In");
                    //return View(foodCheckIn);                   
                } else
                {
                    _context.Add(foodCheckIn);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Denne person er blive tilføjet! ";


                    return RedirectToAction(nameof(Index));
                }
                
             
            }



            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "FirstName", foodCheckIn.GuestId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNr", foodCheckIn.RoomId);
            return View(foodCheckIn);
        }

        // GET: FoodCheckIn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCheckIn = await _context.FoodCheckIns.FindAsync(id);
            if (foodCheckIn == null)
            {
                return NotFound();
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "FirstName", foodCheckIn.GuestId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNr", foodCheckIn.RoomId);
            return View(foodCheckIn);
        }

        // POST: FoodCheckIn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FoodCheckIn foodCheckIn)
        {
            if (id != foodCheckIn.FoodCheckInId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodCheckIn);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException)
                {
                    if (!FoodCheckInExists(foodCheckIn.FoodCheckInId))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "FirstName", foodCheckIn.GuestId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNr", foodCheckIn.RoomId);
            return View(foodCheckIn);
        }


        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            FoodCheckIn foodCheckIn = await _context.FoodCheckIns
                .Include(f => f.Guest)
                .Include(f => f.Room)
                .FirstOrDefaultAsync(m => m.FoodCheckInId == id);

            if (foodCheckIn == null)
            {
                //TempData["Error"] = "The page dose not exist!";
            } else
            {
                _context.FoodCheckIns.Remove(foodCheckIn);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Denne værelse er blevet fjernet!";
            }

            return RedirectToAction("Index");
        }



        private bool FoodCheckInExists(int id)
        {
            return _context.FoodCheckIns.Any(e => e.FoodCheckInId == id);
        }
    }
}
