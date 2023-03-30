using System.ComponentModel.DataAnnotations.Schema;

namespace LWI.Models
{
    public class OrdersToCourses
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public Order Order { get; set; }
    }
}
