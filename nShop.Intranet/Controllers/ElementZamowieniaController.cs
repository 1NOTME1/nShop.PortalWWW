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
    public class ElementZamowieniaController : Controller
    {
        private readonly nShopIntranetContext _context;

        public ElementZamowieniaController(nShopIntranetContext context)
        {
            _context = context;
        }

        // GET: ElementZamowienia
        public async Task<IActionResult> Index()
        {
            var nShopIntranetContext = _context.ElementZamowienia.Include(e => e.Produkt).Include(e => e.Zamowienie);
            return View(await nShopIntranetContext.ToListAsync());
        }

        // GET: ElementZamowienia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementZamowienia = await _context.ElementZamowienia
                .Include(e => e.Produkt)
                .Include(e => e.Zamowienie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elementZamowienia == null)
            {
                return NotFound();
            }

            return View(elementZamowienia);
        }

        // GET: ElementZamowienia/Create
        public IActionResult Create()
        {
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "Id", "Nazwa");
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienie, "Id", "Id");
            return View();
        }

        // POST: ElementZamowienia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZamowienieId,ProduktId,Ilosc,CenaJednostkowa")] ElementZamowienia elementZamowienia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elementZamowienia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "Id", "Nazwa", elementZamowienia.ProduktId);
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienie, "Id", "Id", elementZamowienia.ZamowienieId);
            return View(elementZamowienia);
        }

        // GET: ElementZamowienia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementZamowienia = await _context.ElementZamowienia.FindAsync(id);
            if (elementZamowienia == null)
            {
                return NotFound();
            }
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "Id", "Nazwa", elementZamowienia.ProduktId);
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienie, "Id", "Id", elementZamowienia.ZamowienieId);
            return View(elementZamowienia);
        }

        // POST: ElementZamowienia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZamowienieId,ProduktId,Ilosc,CenaJednostkowa")] ElementZamowienia elementZamowienia)
        {
            if (id != elementZamowienia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elementZamowienia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementZamowieniaExists(elementZamowienia.Id))
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
            ViewData["ProduktId"] = new SelectList(_context.Produkt, "Id", "Nazwa", elementZamowienia.ProduktId);
            ViewData["ZamowienieId"] = new SelectList(_context.Zamowienie, "Id", "Id", elementZamowienia.ZamowienieId);
            return View(elementZamowienia);
        }

        // GET: ElementZamowienia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementZamowienia = await _context.ElementZamowienia
                .Include(e => e.Produkt)
                .Include(e => e.Zamowienie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elementZamowienia == null)
            {
                return NotFound();
            }

            return View(elementZamowienia);
        }

        // POST: ElementZamowienia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elementZamowienia = await _context.ElementZamowienia.FindAsync(id);
            if (elementZamowienia != null)
            {
                _context.ElementZamowienia.Remove(elementZamowienia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementZamowieniaExists(int id)
        {
            return _context.ElementZamowienia.Any(e => e.Id == id);
        }
    }
}
