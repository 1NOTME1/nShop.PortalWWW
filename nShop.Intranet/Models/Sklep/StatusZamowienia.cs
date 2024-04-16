using System.ComponentModel.DataAnnotations;

public class StatusZamowienia
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa statusu zamówienia jest wymagana.")]
    [Display(Name = "Status zamówienia")]
    public string Nazwa { get; set; }

    [Display(Name = "Opis statusu")]
    public string Opis { get; set; }
}
