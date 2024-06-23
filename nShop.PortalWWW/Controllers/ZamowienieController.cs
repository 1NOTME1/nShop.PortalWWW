using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nShop.Data.Data;
using nShop.Data.Data.Sklep;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace nShop.PortalWWW.Controllers
{
    public class ZamowienieController : Controller
    {
        private readonly nShopContext _context;

        public ZamowienieController(nShopContext context)
        {
            _context = context;
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> DodajDoKoszyka(int produktId, int ilosc)
        {
            try
            {
                var produkt = await _context.Produkt.FindAsync(produktId);

                if (produkt == null)
                {
                    Debug.WriteLine($"Produkt z ID {produktId} nie został znaleziony.");
                    return NotFound("Produkt nie został znaleziony.");
                }

                var koszyk = await _context.Zamowienie
                    .Include(z => z.ElementyZamowienia)
                    .ThenInclude(e => e.Produkt)
                    .FirstOrDefaultAsync(z => z.UzytkownikId == GetCurrentUserId() && z.StatusZamowieniaId == GetCartStatusId());

                if (koszyk == null)
                {
                    koszyk = new Zamowienie
                    {
                        UzytkownikId = GetCurrentUserId(),
                        StatusZamowieniaId = GetCartStatusId(),
                        DataZamowienia = DateTime.Now
                    };

                    _context.Zamowienie.Add(koszyk);
                    await _context.SaveChangesAsync();
                }

                var elementZamowienia = koszyk.ElementyZamowienia.FirstOrDefault(e => e.ProduktId == produktId);

                if (elementZamowienia == null)
                {
                    elementZamowienia = new ElementZamowienia
                    {
                        ProduktId = produktId,
                        Ilosc = ilosc,
                        CenaJednostkowa = produkt.Cena
                    };

                    koszyk.ElementyZamowienia.Add(elementZamowienia);
                }
                else
                {
                    elementZamowienia.Ilosc += ilosc;
                }

                koszyk.UpdateSuma();

                await _context.SaveChangesAsync();

                return RedirectToAction("Koszyk");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Błąd podczas dodawania produktu do koszyka.");
                return BadRequest("Wystąpił błąd podczas dodawania produktu do koszyka.");
            }
        }


        public async Task<IActionResult> Koszyk()
        {
            var koszyk = await _context.Zamowienie
                .Include(z => z.ElementyZamowienia)
                .ThenInclude(e => e.Produkt)
                .FirstOrDefaultAsync(z => z.UzytkownikId == GetCurrentUserId() && z.StatusZamowieniaId == GetCartStatusId());

            if (koszyk == null)
            {
                koszyk = new Zamowienie
                {
                    UzytkownikId = GetCurrentUserId(),
                    StatusZamowieniaId = GetCartStatusId(),
                    DataZamowienia = DateTime.Now
                };
                _context.Zamowienie.Add(koszyk);
                await _context.SaveChangesAsync();
            }

            return View(koszyk);
        }

        private int GetCurrentUserId()
        {
            return 1;
        }

        private int GetCartStatusId()
        {
            return 1;
        }

        [HttpPost]
        public async Task<IActionResult> UsunZKoszyka(int produktId)
        {
            var koszyk = await _context.Zamowienie
                .Include(z => z.ElementyZamowienia)
                .FirstOrDefaultAsync(z => z.UzytkownikId == GetCurrentUserId() && z.StatusZamowieniaId == GetCartStatusId());

            if (koszyk == null)
            {
                return NotFound("Koszyk nie został znaleziony.");
            }

            var elementZamowienia = koszyk.ElementyZamowienia.FirstOrDefault(e => e.ProduktId == produktId);

            if (elementZamowienia != null)
            {
                koszyk.ElementyZamowienia.Remove(elementZamowienia);
                koszyk.UpdateSuma();
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Koszyk");
        }

        [HttpPost]
        public async Task<IActionResult> PotwierdzZamowienie(int id)
        {
            try
            {
                var zamowienie = await _context.Zamowienie
                    .Include(z => z.ElementyZamowienia)
                    .ThenInclude(e => e.Produkt)
                    .FirstOrDefaultAsync(z => z.Id == id && z.UzytkownikId == GetCurrentUserId() && z.StatusZamowieniaId == GetCartStatusId());

                if (zamowienie == null)
                {
                    return NotFound("Zamówienie nie zostało znalezione.");
                }

                zamowienie.StatusZamowieniaId = GetOrderConfirmedStatusId();

                foreach (var element in zamowienie.ElementyZamowienia)
                {
                    var produkt = element.Produkt;
                    if (produkt != null)
                    {
                        produkt.IloscNaMagazynie -= element.Ilosc;
                        if (produkt.IloscNaMagazynie < 0)
                        {
                            produkt.IloscNaMagazynie = 0; // Zapobiega negatywnej ilości na magazynie
                        }
                        _context.Produkt.Update(produkt);
                    }
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
               Debug.WriteLine(ex, "Błąd podczas potwierdzania zamówienia.");
                return BadRequest("Wystąpił błąd podczas potwierdzania zamówienia.");
            }
        }


        private int GetOrderConfirmedStatusId()
        {
            return 2; // Replace with actual implementation
        }
    }
}
