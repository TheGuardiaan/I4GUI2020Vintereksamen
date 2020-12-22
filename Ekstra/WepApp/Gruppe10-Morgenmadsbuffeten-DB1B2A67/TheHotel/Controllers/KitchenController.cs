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
    [Authorize(Policy = "isKok")]
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kitchen
        public async Task<IActionResult> Index(DateTime? date)
        {
            DateTime iDate;
            if (date.HasValue)
                iDate = (DateTime)date;
            else
                iDate = DateTime.Now.Date;
            

            Kitchen kitchen = new Kitchen();

            kitchen.date = iDate;

            //kitchen.inAdult = await _context.Guests
            //    .Include(g => g.FoodCheckIns)
            //    .Where(g => g.CheckOutDay == iDate) 
            //    .SumAsync(f => f.NoAdults);


            

            kitchen.inAdult = await _context.FoodCheckIns
                .Where(f => f.CheckInDate.Date == iDate)
                .SumAsync(f => f.Guest.NoAdults);


            kitchen.inChildren = await _context.FoodCheckIns
                .Where(f => f.CheckInDate.Date == iDate)
                .SumAsync(f => f.Guest.NoChildren);





            kitchen.expectedAdult = await _context.Guests
                .Where(f => f.Reserve.Date == iDate)
                .SumAsync(f => f.NoAdults);


            kitchen.expectedChildren = await _context.Guests
                .Where(f => f.Reserve.Date == iDate)
                .SumAsync(f => f.NoChildren);






            return View(kitchen);
        }

    }
}
