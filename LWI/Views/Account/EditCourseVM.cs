using Microsoft.Build.Framework;

namespace LWI.Views.Account
{
    public class EditCourseVM
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? DescriptionShort { get; set; }
        [Required]
        public string? DescriptionLong { get; set; }
        [Required]
        public string? Category { get; set; }
        public bool IsEco { get; set; }
    }
}
