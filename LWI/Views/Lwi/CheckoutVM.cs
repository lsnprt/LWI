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
        [Display(Name = "CCV nummer")]
        [Required(ErrorMessage = "Ange dit CVV")]
        [DataType(DataType.Password)]
        [Range(000, 999, ErrorMessage = "Ogiltig CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Fel längd")]
        public string CVVNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Expiration { get; set; }

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
        [Display(Name = "Land")]
        [EnumDataType(typeof(Country))]
        public Country Country { get; set; }

        public int CourseIdsCount { get; set; }
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
