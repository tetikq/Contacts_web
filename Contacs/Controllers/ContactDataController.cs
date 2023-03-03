using Contacs.Data;
using Contacs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;


namespace Contacs.Controllers
{
    public class ContactDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactData
        public async Task<IActionResult> Index()
        {
              return _context.ContactData != null ? 
                          View(await _context.ContactData.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ContactData'  is null.");
        }


        // GET: ContactData/ShowSearchForm

        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: ContactData/ShowSearchResult

        public async Task<IActionResult> ShowSearchResult(String SearchPhrase)
        {
            ViewBag.location_name = SearchPhrase;
            return View("Index", await _context.ContactData.Where(j => j.location.Contains(SearchPhrase)).ToListAsync());
        }


        // GET: ContactData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactData == null)
            {
                return NotFound();
            }

            var contactData = await _context.ContactData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactData == null)
            {
                return NotFound();
            }

            return View(contactData);
        }

        // GET: ContactData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UUID,name,lastname,Number,location,company,email")] ContactData contactData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactData);
        }

        // GET: ContactData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactData == null)
            {
                return NotFound();
            }

            var contactData = await _context.ContactData.FindAsync(id);
            if (contactData == null)
            {
                return NotFound();
            }
            return View(contactData);
        }

        // POST: ContactData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UUID,name,lastname,Number,location,company,email")] ContactData contactData)
        {
            if (id != contactData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDataExists(contactData.Id))
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
            return View(contactData);
        }

        // GET: ContactData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactData == null)
            {
                return NotFound();
            }

            var contactData = await _context.ContactData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactData == null)
            {
                return NotFound();
            }

            return View(contactData);
        }

        // POST: ContactData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactData == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ContactData'  is null.");
            }
            var contactData = await _context.ContactData.FindAsync(id);
            if (contactData != null)
            {
                _context.ContactData.Remove(contactData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactDataExists(int id)
        {
          return (_context.ContactData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
