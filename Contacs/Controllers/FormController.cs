using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contacs.Data;
using Contacs.Models;

namespace Contacs.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Form
        public async Task<IActionResult> Index()
        {
              return _context.ShowSearchForm != null ? 
                          View(await _context.ShowSearchForm.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ShowSearchForm'  is null.");
        }

        // GET: Form/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShowSearchForm == null)
            {
                return NotFound();
            }

            var showSearchForm = await _context.ShowSearchForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showSearchForm == null)
            {
                return NotFound();
            }

            return View(showSearchForm);
        }

        // GET: Form/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Form/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UUID,date,status")] ShowSearchForm showSearchForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showSearchForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showSearchForm);
        }

        // GET: Form/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShowSearchForm == null)
            {
                return NotFound();
            }

            var showSearchForm = await _context.ShowSearchForm.FindAsync(id);
            if (showSearchForm == null)
            {
                return NotFound();
            }
            return View(showSearchForm);
        }

        // POST: Form/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UUID,date,status")] ShowSearchForm showSearchForm)
        {
            if (id != showSearchForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showSearchForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowSearchFormExists(showSearchForm.Id))
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
            return View(showSearchForm);
        }

        // GET: Form/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShowSearchForm == null)
            {
                return NotFound();
            }

            var showSearchForm = await _context.ShowSearchForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showSearchForm == null)
            {
                return NotFound();
            }

            return View(showSearchForm);
        }

        // POST: Form/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShowSearchForm == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShowSearchForm'  is null.");
            }
            var showSearchForm = await _context.ShowSearchForm.FindAsync(id);
            if (showSearchForm != null)
            {
                _context.ShowSearchForm.Remove(showSearchForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowSearchFormExists(int id)
        {
          return (_context.ShowSearchForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
