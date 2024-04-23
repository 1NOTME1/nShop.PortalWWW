using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nShop.Data.Data;
using nShop.Data.Data.Sklep;

public class PulpitNawigacyjnyController : Controller
{
    private readonly nShopContext _context;

    public PulpitNawigacyjnyController(nShopContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        Console.WriteLine("Rozpoczęcie pobierania danych...");

        var liczbaZamowien = await _context.Zamowienie.CountAsync();
        Console.WriteLine($"Liczba zamówień: {liczbaZamowien}");

        bool zamowieniaExist = liczbaZamowien > 0;
        decimal lacznaKwotaSprzedazy = zamowieniaExist ? await _context.Zamowienie.SumAsync(z => z.Suma) : 0;
        Console.WriteLine($"Łączna kwota sprzedaży: {lacznaKwotaSprzedazy}");

        var produktyWymagajaceUwagi = await _context.Produkt
            .Where(p => p.IloscNaMagazynie <= 10)
            .Select(p => new ProduktInfo { Nazwa = p.Nazwa, IloscNaMagazynie = p.IloscNaMagazynie })
            .ToListAsync();

        if (!produktyWymagajaceUwagi.Any())
        {
            Console.WriteLine("Brak produktów wymagających uwagi.");
        }

        var viewModel = new PulpitNawigacyjny
        {
            LiczbaZamowien = liczbaZamowien,
            LacznaKwotaSprzedazy = lacznaKwotaSprzedazy,
            ProduktyWymagajaceUwagi = produktyWymagajaceUwagi
        };

        return View(viewModel);
    }




}
