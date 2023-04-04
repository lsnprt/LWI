using Microsoft.AspNetCore.Identity;

namespace LWI.Models
{
    public class CourseCreator : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Occupation  { get; set; }
        public string? Description { get; set; }
        public List<Course> Courses { get; set; }
    }
}
