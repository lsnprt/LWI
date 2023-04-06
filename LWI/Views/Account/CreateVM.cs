using System.ComponentModel.DataAnnotations;

namespace LWI.Views.Account
{
    public class CreateVM
    {
        [Required(ErrorMessage = "Välj användarnamn")]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Välj ett lösenord")]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vänligen ange lösenordet igen")]
        [DataType(DataType.Password)]
        [Display(Name = "Upprepa lösenord")]
        [Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte")]
        public string PasswordRepeat { get; set; }

        [Required(ErrorMessage = "Ange din mailadress")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mailadress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ange ditt förnamn")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ange ditt efternamn")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Yrke")]
        public string? Profession { get; set; }

        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }
    }
}
