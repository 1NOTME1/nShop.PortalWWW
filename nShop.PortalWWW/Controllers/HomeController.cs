using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nShop.Data.Data;
using nShop.PortalWWW.Models;
using System.Diagnostics;

namespace nShop.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly nShopContext _context;

        public HomeController(ILogger<HomeController> logger, nShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        //w parametrze id jest numer storny, ktory klik, a przy 1 uruchomieniu witryny id wynosi 1
        public async Task<IActionResult> Index(int? id)
        {
            //z bazy danych pobiearmy wszystkie strony posortowane wzgledem pozycji
            //i zapisujemy je w ViewBagu
            ViewBag.ModelStrony = await _context.Strona.OrderBy(s=>s.Pozycja).ToListAsync();
            ViewBag.ModelProdukt = await _context.Produkt.OrderBy(s=>s.Id).ToListAsync();
            
            if(id == null)
                id = 1;

            var item = await _context.Strona.FindAsync(id);

            return View(item);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
