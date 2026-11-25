
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Guest;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.Controllers 
{
    [Authorize]
    public class GuestsController : Controller
    {
        private readonly GuestsDbContext _context;

        public GuestsController(GuestsDbContext context)
        {
            _context = context;
        }

        // GET: GUESTSS
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guest.ToListAsync());
        }

        // GET: GUESTSS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guests == null)
            {
                return NotFound();
            }

            return View(guests);
        }

        // GET: GUESTSS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GUESTSS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Phone")] Guests guests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guests);
        }

        // GET: GUESTSS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guest.FindAsync(id);
            if (guests == null)
            {
                return NotFound();
            }
            return View(guests);
        }

        // POST: GUESTSS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,Address,Phone")] Guests guests)
        {
            if (id != guests.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestsExists(guests.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(guests);
        }

        // GET: GUESTSS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guests == null)
            {
                return NotFound();
            }

            return View(guests);
        }

        // POST: GUESTSS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var guests = await _context.Guest.FindAsync(id);
            if (guests != null)
            {
                _context.Guest.Remove(guests);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestsExists(int? id)
        {
            return _context.Guest.Any(e => e.Id == id);
        }
    }

}