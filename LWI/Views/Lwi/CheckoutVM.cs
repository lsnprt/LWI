using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LWI.Views.Lwi
{
    public class CheckoutVM
    {
        [Required(ErrorMessage = "Ange din emailadress")]
        [EmailAddress(ErrorMessage = "Ange en giltig emailadress")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ange dit kortnummer")]
        [CreditCard(ErrorMessage = "Kortnummer ogiltigt")]
        [Display(Name = "Kreditkortsnummer")]
        public string CCNumber { get; set; }

        [Required(ErrorMessage = "Ange dit CVV")]
        [PasswordPropertyText]
        [Display(Name = "CCV nummer")]
        public int CVVNumber { get; set; }

        [Required(ErrorMessage = "Ange namnet på kortägaren")]
        [Display(Name = "Kreditkorts innehavare")]
        public string CCHolder { get; set; }

        [Required(ErrorMessage = "Ange adress för fakturering")]
        [Display(Name = "Adress")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ange en stad")]
        [Display(Name = "Stad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ange ett postnummer")]
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }

        [Display(Name = "Total kostnad")]
        public decimal Total { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Country")]
        [Display(Name = "Land")]
        public Country Country { get; set; }

        bool Paid { get; set; }
    }

    public enum Country
    {
        Sverige,
        Findland,
        Norge,
        Danmark,
        Island
    }
}
