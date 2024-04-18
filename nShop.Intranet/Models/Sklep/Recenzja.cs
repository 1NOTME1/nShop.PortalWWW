using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
