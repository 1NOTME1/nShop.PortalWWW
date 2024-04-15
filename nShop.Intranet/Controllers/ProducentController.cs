using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nShop.Intranet.Data;

namespace nShop.Intranet.Controllers
{
    public class ProducentController : Controller
    {
        private readonly nShopIntranetContext _context;

        public ProducentController(nShopIntranetContext context)
        {
            _context = context;
        }

        // GET: Producent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producent.ToListAsync());
        }

        // GET: Producent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producent = await _context.Producent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // GET: Producent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,SciezkaLogo")] Producent producent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producent);
        }

        // GET: Producent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producent = await _context.Producent.FindAsync(id);
            if (producent == null)
            {
                return NotFound();
            }
            return View(producent);
        }

        // POST: Producent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,SciezkaLogo")] Producent producent)
        {
            if (id != producent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducentExists(producent.Id))
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
            return View(producent);
        }

        // GET: Producent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producent = await _context.Producent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // POST: Producent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producent = await _context.Producent.FindAsync(id);
            if (producent != null)
            {
                _context.Producent.Remove(producent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducentExists(int id)
        {
            return _context.Producent.Any(e => e.Id == id);
        }
    }
}
