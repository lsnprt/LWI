using System.ComponentModel.DataAnnotations;

namespace LWI.Views.Account
{
    public class AddCourseVM
    {
        [Required(ErrorMessage = "Ange Pris")]
        [Display(Name = "Pris")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Ange Namn")]
        [Display(Name = "Kursnamn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ange Kort Beskrivning")]
        [Display(Name = "Kort Beskrivning")]
        public string? DescriptionShort { get; set; }
        [Required(ErrorMessage = "Ange Lång Beskrivning")]
        [Display(Name = "Beskrivning")]
        public string? DescriptionLong { get; set; }
        [Required(ErrorMessage = "Ange Kategori")]
        [Display(Name = "Kurskategori")]
        public string? Category { get; set; }
        public bool IsEco { get; set; }
    }
}
