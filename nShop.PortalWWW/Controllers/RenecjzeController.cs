using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nShop.Data.Data;
using nShop.Data.Data.Sklep;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace nShop.PortalWWW.Controllers
{
    public class RecenzjeController : Controller
    {
        private readonly nShopContext _context;

        public RecenzjeController(nShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var recenzje = await _context.Recenzja
                .Include(r => r.Uzytkownik)
                .Include(r => r.Produkt)
                .ToListAsync();
            return View(recenzje);
        }

        [HttpGet]
        public IActionResult DodajRecenzje()
        {
            ViewBag.Produkty = new SelectList(_context.Produkt, "Id", "Nazwa");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DodajRecenzje(Recenzja recenzja)
        {
            if (ModelState.IsValid)
            {
                _context.Recenzja.Add(recenzja);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Produkty = new SelectList(_context.Produkt, "Id", "Nazwa", recenzja.ProduktId);
            return View(recenzja);
        }
    }
}
