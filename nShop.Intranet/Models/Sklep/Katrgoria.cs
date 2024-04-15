using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nShop.Intranet.Models.Sklep
{
    public class Kategoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana.")]
        [Display(Name = "Nazwa kategorii")]
        public string Nazwa { get; set; }

        [Display(Name = "Opis kategorii")]
        public string Opis { get; set; }

        // Dodaj odpowiednią kolekcję Produktów
        public ICollection<Produkt> Produkty { get; } = new List<Produkt>();
    }
}
