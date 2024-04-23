using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class Zamowienie
    {
        public int Id { get; set; }

        [Display(Name = "Uzytkownik")]
        public int UzytkownikId { get; set; }

        [Display(Name = "Data zamowienia")]
        public DateTime DataZamowienia { get; set; }

        [Display(Name = "Status zamowienia")]
        public int StatusZamowieniaId { get; set; }

        [Display(Name = "Suma")]
        public decimal Suma { get; set; }

        public Uzytkownik? Uzytkownik { get; set; }
        public StatusZamowienia? StatusZamowienia { get; set; }
        public ICollection<ElementZamowienia> ElementyZamowienia { get; } = new List<ElementZamowienia>();

        public void UpdateSuma()
        {
            this.Suma = this.ElementyZamowienia.Sum(e => e.Ilosc * e.CenaJednostkowa);
        }

    }
}
