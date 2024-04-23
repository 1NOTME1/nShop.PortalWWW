using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class Recenzja
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tekst recenzji jest wymagany.")]
        [Display(Name = "Recenzja")]
        public string Tekst { get; set; }

        [Range(1, 5, ErrorMessage = "Ocena musi być w zakresie od 1 do 5.")]
        [Display(Name = "Ocena")]
        public int Ocena { get; set; }

        [Required]
        [Display(Name = "ID Użytkownika")]
        public int UzytkownikId { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }

        [Required]
        [Display(Name = "ID Produktu")]
        public int ProduktId { get; set; }
        public Produkt? Produkt { get; set; }
    }
}
