using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class ElementZamowienia
    {
        public int Id { get; set; }

        [Display(Name = "Zamowienie")]
        public int ZamowienieId { get; set; }

        [Display(Name = "Produkt")]
        public int ProduktId { get; set; }

        [Display(Name = "Ilosc")]
        public int Ilosc { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Cena jednostkowa musi być większa niż 0.")]
        [Display(Name = "Cena jednostkowa")]
        public decimal CenaJednostkowa { get; set; }

        public Zamowienie? Zamowienie { get; set; }
        public Produkt? Produkt { get; set; }
    }
}
