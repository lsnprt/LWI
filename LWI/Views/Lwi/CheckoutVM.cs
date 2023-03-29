using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text.RegularExpressions;

namespace LWI.Views.Lwi
{
    public class CheckoutVM
    {
        [Required(ErrorMessage = "Ange din emailadress")]
        [EmailAddress(ErrorMessage = "Ange en giltig emailadress")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Ange dit kortnummer")]
        [CreditCard(ErrorMessage = "Kortnummer ogiltigt")]
        public string? CCNumber { get; set; }

        [Required(ErrorMessage = "Ange dit CVV")]
        [DataType(DataType.Password)]
        [Range(000, 999, ErrorMessage = "Ogiltig CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Fel längd")]
        public string CVVNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Expiration { get; set; }

        [Required(ErrorMessage = "Ange namnet på kortägaren")]
        public string? CCHolder { get; set; }

        [Required(ErrorMessage = "Ange adress för fakturering")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Ange en stad")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Ange ett postnummer")]
        public string? ZipCode { get; set; }

        public decimal? Total { get; set; }

        [EnumDataType(typeof(Country)), Display(Name = "Land")]
        public Country? Country { get; set; }

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
