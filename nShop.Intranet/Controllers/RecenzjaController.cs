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
    public class RecenzjaController : Controller
    {
        private readonly nShopContext _context;

        public RecenzjaController(nShopContext context)
        {
            _context = context;
        }

        // GET: Recenzja
        public async Task<IActionResult> Index()
        {
            var recenzje = _context.Recenzja
                .Include(r => r.Produkt)
                .Include(r => r.Uzytkownik)
                .ToListAsync();

            return View(await recenzje);
        }


        // GET: Recenzja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzja
                .Include(r => r.Uzytkownik) // Załaduj informacje o użytkowniku
                .Include(r => r.Produkt)    // Załaduj informacje o produkcie
                .FirstOrDefaultAsync(m => m.Id == id);

            if (recenzja == null)
            {
                return NotFound();
            }

            return View(recenzja);
        }


        // GET: Recenzja/Create
        public IActionResult Create()
        {
            // Pobranie listy użytkowników
            ViewBag.Uzytkownicy = new SelectList(_context.Uzytkownik.ToList(), "Id", "Email"); // lub "Imie Nazwisko" jako tekst

            // Pobranie listy produktów
            ViewBag.Produkty = new SelectList(_context.Produkt.ToList(), "Id", "Nazwa");

            return View();
        }


        // POST: Recenzja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tekst,Ocena,UzytkownikId,ProduktId")] Recenzja recenzja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recenzja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Ponownie przygotuj listy w przypadku błędów
            ViewBag.Uzytkownicy = new SelectList(_context.Uzytkownik.ToList(), "Id", "Email");
            ViewBag.Produkty = new SelectList(_context.Produkt.ToList(), "Id", "Nazwa");

            return View(recenzja);
        }


        // GET: Recenzja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzja
                .Include(r => r.Uzytkownik) 
                .Include(r => r.Produkt)    
                .FirstOrDefaultAsync(m => m.Id == id);

            if (recenzja == null)
            {
                return NotFound();
            }

            // Przygotuj SelectListy
            ViewBag.Uzytkownicy = new SelectList(_context.Uzytkownik.ToList(), "Id", "Email");
            ViewBag.Produkty = new SelectList(_context.Produkt.ToList(), "Id", "Nazwa");

            return View(recenzja);
        }


        // POST: Recenzja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tekst,Ocena,UzytkownikId,ProduktId")] Recenzja recenzja)
        {
            if (id != recenzja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recenzja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecenzjaExists(recenzja.Id))
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
            // Przygotuj SelectListy w przypadku błędu
            ViewBag.Uzytkownicy = new SelectList(_context.Uzytkownik.ToList(), "Id", "Email");
            ViewBag.Produkty = new SelectList(_context.Produkt.ToList(), "Id", "Nazwa");

            return View(recenzja);
        }


        // GET: Recenzja/Delete/5
        // GET: Recenzja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzja = await _context.Recenzja
                .Include(r => r.Uzytkownik) // Upewnij się, że dane użytkownika są załadowane
                .Include(r => r.Produkt)    // Upewnij się, że dane produktu są załadowane
                .FirstOrDefaultAsync(m => m.Id == id);

            if (recenzja == null)
            {
                return NotFound();
            }

            return View(recenzja);
        }


        // POST: Recenzja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recenzja = await _context.Recenzja.FindAsync(id);
            if (recenzja != null)
            {
                _context.Recenzja.Remove(recenzja);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        private bool RecenzjaExists(int id)
        {
            return _context.Recenzja.Any(e => e.Id == id);
        }
    }
}
