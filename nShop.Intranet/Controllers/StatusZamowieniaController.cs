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
    public class StatusZamowieniaController : Controller
    {
        private readonly nShopIntranetContext _context;

        public StatusZamowieniaController(nShopIntranetContext context)
        {
            _context = context;
        }

        // GET: StatusZamowienia
        public async Task<IActionResult> Index()
        {
            var zamowieniaZStatusami = _context.StatusZamowienia
                .Include(sz => sz.Zamowienia)
                    .ThenInclude(z => z.ElementyZamowienia)
                    .ThenInclude(ez => ez.Produkt)
                .ToListAsync();

            return View(await zamowieniaZStatusami);
        }


        // GET: StatusZamowienia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusZamowienia = await _context.StatusZamowienia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusZamowienia == null)
            {
                return NotFound();
            }

            return View(statusZamowienia);
        }

        // GET: StatusZamowienia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusZamowienia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis")] StatusZamowienia statusZamowienia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusZamowienia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusZamowienia);
        }

        // GET: StatusZamowienia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusZamowienia = await _context.StatusZamowienia.FindAsync(id);
            if (statusZamowienia == null)
            {
                return NotFound();
            }
            return View(statusZamowienia);
        }

        // POST: StatusZamowienia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis")] StatusZamowienia statusZamowienia)
        {
            if (id != statusZamowienia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusZamowienia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusZamowieniaExists(statusZamowienia.Id))
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
            return View(statusZamowienia);
        }

        // GET: StatusZamowienia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusZamowienia = await _context.StatusZamowienia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusZamowienia == null)
            {
                return NotFound();
            }

            return View(statusZamowienia);
        }

        // POST: StatusZamowienia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusZamowienia = await _context.StatusZamowienia.FindAsync(id);
            if (statusZamowienia != null)
            {
                _context.StatusZamowienia.Remove(statusZamowienia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusZamowieniaExists(int id)
        {
            return _context.StatusZamowienia.Any(e => e.Id == id);
        }
    }
}
