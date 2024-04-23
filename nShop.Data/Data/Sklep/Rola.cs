using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class Rola
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa roli jest wymagana.")]
        [Display(Name = "Rola")]
        public string Nazwa { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; }

        public ICollection<Uzytkownik> Uzytkownicy { get; } = new List<Uzytkownik>();
    }
}
