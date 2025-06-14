using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;

namespace RunGroopWebApp.Controllers
{


    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly ApplicationDbContext _context;
        public ClubController(IClubRepository clubRepository,ApplicationDbContext context)
        {
            _clubRepository = clubRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepository.GetAll();
            return View(clubs);
        }
       
        public async  Task<IActionResult> Detail(int id) //sve kao rute
        {
            var clubs = await _clubRepository.GetByIdAsync(id);
            return View(clubs);
        }
      

      
       

       

        // GET: Clubs/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Adresses, "ID", "ID");
            ViewData["AppUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Name");
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image,AddressId,ClubCategory,AppUserId")] Club club)
        {
            if (ModelState.IsValid)
            {
                _context.Add(club);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Adresses, "ID", "ID", club.AddressId);//promjenom ekrana se mijenja
            ViewData["AppUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Name", club.AppUserId);
            return View(club);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Adresses, "ID", "ID", club.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Name", club.AppUserId);
            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Image,AddressId,ClubCategory,AppUserId")] Club club)
        {
            if (id != club.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(club);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(club.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Adresses, "ID", "ID", club.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Name", club.AppUserId);
            return View(club);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs
                .Include(c => c.Address)
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}
