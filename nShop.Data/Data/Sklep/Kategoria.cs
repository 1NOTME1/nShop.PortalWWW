using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class Kategoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana.")]
        [Display(Name = "Nazwa kategorii")]
        public string Nazwa { get; set; }

        [Display(Name = "Opis kategorii")]
        public string Opis { get; set; }

        public ICollection<Produkt> Produkty { get; } = new List<Produkt>();
    }
}
