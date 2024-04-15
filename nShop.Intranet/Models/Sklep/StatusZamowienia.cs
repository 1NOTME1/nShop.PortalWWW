using System.ComponentModel.DataAnnotations;

public class StatusZamowienia
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa statusu zamowienia jest wymagana.")]
    [Display(Name = "Status zamowienia")]
    public string Nazwa { get; set; }
}