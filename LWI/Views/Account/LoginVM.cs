using System.ComponentModel.DataAnnotations;

namespace LWI.Views.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Vänligen ange ditt användarnamn")]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vänligen ange ditt lösenord")]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
    }
}
