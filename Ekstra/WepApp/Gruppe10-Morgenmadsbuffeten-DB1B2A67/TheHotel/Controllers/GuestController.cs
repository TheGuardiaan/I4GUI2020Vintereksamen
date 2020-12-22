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

    [Authorize(Policy = "isReceptionist")]
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guest
        public async Task<IActionResult> Index(int p = 1)
        {
            

            //string firstName = _context.Guests.FirstOrDefault(r => r.FirstName != "");

            //string lastName = await _context.Guests.Where(r => r.LastName = r.FirstName);

            //string fullName = firstName + lastName;
            //ViewData["fullName"] = fullName;




            int pageSize = 20;
            var guests = _context.Guests.OrderByDescending(x => x.GuestId)
                                                .Skip((p - 1) * pageSize)
                                                .Include(f => f.Room)
                                                .Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = 3;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Guests.Count() / pageSize);

            return View(await guests.ToListAsync());
        }

        
        // GET: Guest/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNr");
            return View();
        }

        // POST: Guest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                var checkFirstName = await _context.Guests.FirstOrDefaultAsync(x => x.FirstName == guest.FirstName);
                var checkLastName = await _context.Guests.FirstOrDefaultAsync(x => x.LastName == guest.LastName);
                if (checkFirstName != null && checkLastName != null)
                {
                    ModelState.AddModelError("", "This Guest Has Already Been Checked Into The Hotel ");
                    //return View(guest);
                } else
                {
                    guest.FullName = guest.FirstName + " " + guest.LastName;

                    _context.Add(guest);

                    Room room = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomId == guest.RoomId);
                    if (room != null)
                    {
                        room.RoomStatus = true;
                        _context.Rooms.Update(room);
                    }

                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Denne Gæst er blive tilføjet! ";

                    return RedirectToAction(nameof(Index));
                }

                
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNr", guest.RoomId);
            return View(guest);
        }

        // GET: Guest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNr", guest.RoomId);
            return View(guest);
        }

        // POST: Guest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Guest guest)
        {
            if (id != guest.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              

                try
                {


                    Room roomOld = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomId == x.Guests.FirstOrDefault
                                                                            (g => g.GuestId == guest.GuestId).RoomId);
                    if (roomOld != null)
                    {
                        roomOld.RoomStatus = false;
                        _context.Rooms.Update(roomOld);
                        
                    }
                    guest.FullName = guest.FirstName + " " + guest.LastName;
                    _context.Update(guest);

                    Room room = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomId == guest.RoomId);
                    if (room != null)
                    {
                        room.RoomStatus = true;
                        _context.Rooms.Update(room);
                    } 

                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GuestId)) 
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomNr", guest.RoomId);
            return View(guest);
        }

        // GET: Guest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Guest guest = await _context.Guests.FindAsync(id);

            if (guest == null)
            {
                //TempData["Error"] = "The page dose not exist!";
            } else
            {
                _context.Guests.Remove(guest);

                Room room = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomId == guest.RoomId);
                if (room != null)
                {
                    room.RoomStatus = false;
                    _context.Rooms.Update(room);
                }


                await _context.SaveChangesAsync();




                TempData["Success"] = "Denne gæst er blevet fjernet!";
            }

            return RedirectToAction("Index");
        }


        private bool GuestExists(int id)
        {
            return _context.Guests.Any(e => e.GuestId == id);
        }
    }
}
