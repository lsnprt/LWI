namespace LWI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string? Name { get; set; }
        public string? DescriptionShort { get; set; }
        public string? DescriptionLong { get; set; }
        public string? ImgName { get; set; }
        public string? ImgAlt { get; set; }
        public string? Category { get; set; }
        public string Teacher { get; set; }
        public bool IsEco { get; set; }

        public List<OrdersToCourses> OrdersToCourses { get; set; }
    }
}
