using System.ComponentModel.DataAnnotations;

namespace LWI.Views.Account
{
    public class EditProfileVM
    {
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Yrke")]
        public string Profession { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
    }
}