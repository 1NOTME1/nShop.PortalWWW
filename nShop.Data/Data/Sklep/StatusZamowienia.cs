using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class StatusZamowienia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa statusu zamówienia jest wymagana.")]
        [Display(Name = "Status zamówienia")]
        public string Nazwa { get; set; }

        [Display(Name = "Opis statusu")]
        public string Opis { get; set; }

        public ICollection<Zamowienie>? Zamowienia { get; set; }
    }
}
