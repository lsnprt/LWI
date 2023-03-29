using LWI.Views.Lwi;
using System.ComponentModel.DataAnnotations;

namespace LWI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CCNumber { get; set; }

        public string CCHolder { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public decimal Total { get; set; }
        public Country Country { get; set; }

        public List<OrdersToCourses> OrdersToCourses { get; set; }
    }
}
