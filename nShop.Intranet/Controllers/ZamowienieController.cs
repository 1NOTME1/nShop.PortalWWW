using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nShop.Data.Data;
using nShop.Data.Data.Sklep;

namespace nShop.Intranet.Controllers
{
    public class ZamowienieController : Controller
    {
        private readonly nShopContext _context;

        public ZamowienieController(nShopContext context)
        {
            _context = context;
        }

        // GET: Zamowienie
        public async Task<IActionResult> Index()
        {
            var nShopIntranetContext = _context.Zamowienie.Include(z => z.StatusZamowienia).Include(z => z.Uzytkownik);
            return View(await nShopIntranetContext.ToListAsync());
        }

        // GET: Zamowienie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.StatusZamowienia)
                .Include(z => z.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienie/Create
        public IActionResult Create()
        {
            ViewData["StatusZamowieniaId"] = new SelectList(_context.Set<StatusZamowienia>(), "Id", "Nazwa");
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownik, "Id", "Email");
            return View();
        }

        // POST: Zamowienie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UzytkownikId,DataZamowienia,StatusZamowieniaId,Suma")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusZamowieniaId"] = new SelectList(_context.Set<StatusZamowienia>(), "Id", "Nazwa", zamowienie.StatusZamowieniaId);
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownik, "Id", "Email", zamowienie.UzytkownikId);
            return View(zamowienie);
        }

        // GET: Zamowienie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            ViewData["StatusZamowieniaId"] = new SelectList(_context.Set<StatusZamowienia>(), "Id", "Nazwa", zamowienie.StatusZamowieniaId);
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownik, "Id", "Email", zamowienie.UzytkownikId);
            return View(zamowienie);
        }

        // POST: Zamowienie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UzytkownikId,DataZamowienia,StatusZamowieniaId,Suma")] Zamowienie zamowienie)
        {
            if (id != zamowienie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.Id))
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
            ViewData["StatusZamowieniaId"] = new SelectList(_context.Set<StatusZamowienia>(), "Id", "Nazwa", zamowienie.StatusZamowieniaId);
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownik, "Id", "Email", zamowienie.UzytkownikId);
            return View(zamowienie);
        }

        // GET: Zamowienie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.StatusZamowienia)
                .Include(z => z.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie != null)
            {
                _context.Zamowienie.Remove(zamowienie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienie.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddOrUpdateElement(int zamowienieId, ElementZamowienia element)
        {
            var zamowienie = await _context.Zamowienie
                .Include(z => z.ElementyZamowienia)
                .FirstOrDefaultAsync(z => z.Id == zamowienieId);

            if (zamowienie == null)
            {
                return NotFound();
            }

            // Dodanie lub aktualizacja elementu zamówienia
            // Tu logika dodawania lub aktualizacji

            zamowienie.UpdateSuma();
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = zamowienieId });
        }

        public async Task<IActionResult> DeleteElement(int zamowienieId, int elementId)
        {
            var element = await _context.ElementZamowienia.FindAsync(elementId);
            if (element != null)
            {
                _context.ElementZamowienia.Remove(element);
                await _context.SaveChangesAsync();

                var zamowienie = await _context.Zamowienie
                    .Include(z => z.ElementyZamowienia)
                    .FirstOrDefaultAsync(z => z.Id == zamowienieId);

                if (zamowienie != null)
                {
                    zamowienie.UpdateSuma();
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Details", new { id = zamowienieId });
        }

    }
}
