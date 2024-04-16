using System.ComponentModel.DataAnnotations;

public class Recenzja
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tekst recenzji jest wymagany.")]
    [Display(Name = "Recenzja")]
    public string Tekst { get; set; }

    [Range(1, 5, ErrorMessage = "Ocena musi być w zakresie od 1 do 5.")]
    [Display(Name = "Ocena")]
    public int Ocena { get; set; }

    public Produkt? Produkt { get; set; }
    public Uzytkownik? Uzytkownik { get; set; }
}