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
    [Authorize (Policy = "isReceptionist")]
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Room
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Rooms.ToListAsync());
        //}

        // GET: Room
        public async Task<IActionResult> Index(int p = 1)
        {

            int availableRooms = await _context.Rooms.CountAsync(r => r.RoomStatus == false);
            ViewData["availableRooms"] = availableRooms;

            int busyRooms = await _context.Rooms.CountAsync(r => r.RoomStatus == true);
            ViewData["busyRooms"] = busyRooms;



            int pageSize = 20;
            var rooms = _context.Rooms.OrderByDescending(x => x.RoomId)
                                                .Skip((p - 1) * pageSize)
                                                .Take(pageSize);


            ViewBag.PageNumber = p;
            ViewBag.PageRange = 3;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Rooms.Count() / pageSize);





            return View(await rooms.ToListAsync());

        }



        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }


            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (ModelState.IsValid)

            {
                var check = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomNr == room.RoomNr);
                if (check != null)
                {
                    ModelState.AddModelError("", "The Room Already Exists.");
                    //return View(room);
                } else
                {
                    _context.Add(room);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                
            }
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }


        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Room room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                //TempData["Error"] = "The page dose not exist!";
            } else
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Denne værelse er blevet fjernet!";
            }

            return RedirectToAction("Index");
        }



        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }
    }
}
