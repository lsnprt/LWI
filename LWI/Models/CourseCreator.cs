using Microsoft.AspNetCore.Identity;

namespace LWI.Models
{
    public class CourseCreator : IdentityUser
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Occupation  { get; set; }
        public string? Description { get; set; }
    }
}
