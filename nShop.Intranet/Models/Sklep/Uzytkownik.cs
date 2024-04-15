using System.ComponentModel.DataAnnotations;

public class Uzytkownik
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Email jest wymagany.")]
    [EmailAddress(ErrorMessage = "Nieprawidlowy format adresu email.")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Imie")]
    public string Imie { get; set; }

    [Display(Name = "Nazwisko")]
    public string Nazwisko { get; set; }

    [Display(Name = "Haslo")]
    public string Haslo { get; set; }

    [Display(Name = "Rola")]
    public int RolaId { get; set; }

    public Rola Rola { get; set; }
}