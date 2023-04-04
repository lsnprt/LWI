using System.ComponentModel.DataAnnotations;

namespace LWI.Views.Account
{
    public class CreateVM
    {
        [Required]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Upprepa lösenord")]
        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mailadress")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Yrke")]
        public string Profession { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
    }
}
