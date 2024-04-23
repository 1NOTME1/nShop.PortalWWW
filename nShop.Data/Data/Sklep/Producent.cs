using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class Producent
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa producenta jest wymagana.")]
        [Display(Name = "Nazwa producenta")]
        public string Nazwa { get; set; }

        [Display(Name = "Opis producenta")]
        public string Opis { get; set; }

        [Display(Name = "Logo")]
        public string SciezkaLogo { get; set; } // Ścieżka do pliku z logo producenta

        public ICollection<Produkt> Produkty { get; } = new List<Produkt>();
    }
}
