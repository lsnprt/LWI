using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LWI.Views.Account
{
    public class AddCourseVM
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string? DescriptionShort { get; set; }
        public string? DescriptionLong { get; set; }
        public string? Category { get; set; }
        public bool IsEco { get; set; }
    }
}
