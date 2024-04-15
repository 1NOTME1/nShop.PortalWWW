using nShop.Intranet.Models.Sklep;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produkt
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
    [Display(Name = "Nazwa")]
    public string Nazwa { get; set; }

    [Display(Name = "Opis")]
    public string Opis { get; set; }

    [Required(ErrorMessage = "Cena jest wymagana.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Cena musi być większa niż 0.")]
    [Column(TypeName = "money")]
    [Display(Name = "Cena")]
    public decimal Cena { get; set; }

    [Display(Name = "Kategoria")]
    public int KategoriaId { get; set; }

    [Display(Name = "Producent")]
    public int ProducentId { get; set; }

    [Display(Name = "Zdjęcie")]
    public string SciezkaZdjecia { get; set; } // Ścieżka do pliku ze zdjęciem

    public Kategoria Kategoria { get; set; }
    public Producent Producent { get; set; }
    public ICollection<Recenzja> Recenzje { get; } = new List<Recenzja>();
}
