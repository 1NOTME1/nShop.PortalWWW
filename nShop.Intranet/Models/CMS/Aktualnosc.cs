using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nShop.Intranet.Models.CMS
{
    public class Aktualnosc
    {
        [Key]
        public int IdAktualnosci { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł odnośnika do aktualnosci")]
        [MaxLength(10, ErrorMessage = "Tytuł powinien zawierać max 10 znaków")]
        [Display(Name = "Tytuł Odnośnika")]
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł aktualnosci")]
        [MaxLength(30, ErrorMessage = "Tytuł aktualnosci powinien zawierać max 30 znaków")]
        [Display(Name = "Tytuł Aktualnosci")]
        public required string Tytul { get; set; }

        [Required(ErrorMessage = "Wpisz treść aktualnosci")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Treść")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }
    }
}
