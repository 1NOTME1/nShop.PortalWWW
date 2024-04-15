using System.ComponentModel.DataAnnotations;

public class Zamowienie
{
    public int Id { get; set; }

    [Display(Name = "Uzytkownik")]
    public int UzytkownikId { get; set; }

    [Display(Name = "Data zamowienia")]
    public DateTime DataZamowienia { get; set; }

    [Display(Name = "Status zamowienia")]
    public int StatusZamowieniaId { get; set; }

    [Display(Name = "Suma")]
    public decimal Suma { get; set; }

    public Uzytkownik Uzytkownik { get; set; }
    public StatusZamowienia StatusZamowienia { get; set; }
    public ICollection<ElementZamowienia> ElementyZamowienia { get; } = new List<ElementZamowienia>();
}