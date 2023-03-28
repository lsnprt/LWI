using System.ComponentModel.DataAnnotations;

namespace LWI.Views.Lwi
{
    public class CheckoutVM
    {
        [Required(ErrorMessage = "Ange din emailadress")]
        [EmailAddress(ErrorMessage = "Ange en giltig emailadress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ange dit kortnummer")]
        [CreditCard(ErrorMessage = "Kortnummer ogiltigt")]
        public string CCNumber { get; set; }

        [Required(ErrorMessage = "Ange namnet på kortägaren")]
        public string CCHolder { get; set; }

        [Required(ErrorMessage = "Ange adress för fakturering")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ange en stad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ange ett postnummer")]
        public string ZipCode { get; set; }

        public decimal Total { get; set; }
    }
}
