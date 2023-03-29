using System.Data.SqlTypes;
using System.Linq;
using LWI.Views.Lwi;
using Microsoft.AspNetCore.Identity;

namespace LWI.Models
{
    public class DataService
    {
        List<Course> shoppingBag = new List<Course>();
        public DataService()
        {
        }

        List<Course> courses = new List<Course>()
        {
            new Course()
            {
                Id = 1,
                Name = "Pontus lilla röda",
                Teacher = "Pontus",
                DescriptionShort = "Lär dig allt du behöver veta för att skapa din egna revolution",
                DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
                ImgName = "Csharp.png",
                ImgAlt = "blabla",
                Category = "Pontus kurser",
                Price = 1999
            },
            new Course()
            {
                Id = 2,
                Name = "Grundkurs i C#",
                Teacher = "Peter",
                DescriptionShort = "En grundkurs i det objektorienterade språket C#",
                DescriptionLong = "En grundkurs i det objektorienterade språket C#",
                ImgName = "JS.png",
                ImgAlt = "blabla",
                Category = "Programmering",
                Price = 0

            },
			new Course()
			{
				Id = 3,
				Name = "Sortera med Nadine #1",
                Teacher = "Nadine",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "ASP.jpg",
				ImgAlt = "blabla",
				Category = "Nadines kurser",
                Price = 1999
			},new Course()
			{

				Id = 4,
				Name = "Sortera med Nadine #2",
				Teacher="Håkan",
				DescriptionShort = "I Nadines andra sorteringskurs lär vi oss hur man sorterar tegel",
				DescriptionLong = "I Nadines andra sorteringskurs lär vi oss hur man sorterar tegel",
				ImgName = "python.png",
				ImgAlt = "blabla",
				Category = "Nadines kurser",
                Price = 4999
			},

        };

        public CatalogVM[] GetAllCourses()
        {
            return courses
                .Select(c => new CatalogVM
                {
                    Category = c.Category,
                    Price = c.Price,
                    Name = c.Name,
                    Id = c.Id,
                    DescriptionShort = c.DescriptionShort,
                    ImgAlt = c.ImgAlt,
                    ImgName = c.ImgName
                })
                .OrderBy(c => c.Name)
                .ToArray();
        }
        public DetailsVM? GetCourse(int id)
        {
            return courses
                .Select(c => new DetailsVM
                {
                    Category = c.Category,
                    Price = c.Price,
                    Name = c.Name,
                    Id = c.Id,
                    DescriptionLong = c.DescriptionLong,
                    ImgAlt = c.ImgAlt,
                    ImgName = c.ImgName
                })
                .FirstOrDefault(c => c.Id == id)
                ;
        }

        internal void AddToShoppingCart(DetailsVM model)
        {
            var course = courses.Where(o => o.Id == model.Id).FirstOrDefault();
            shoppingBag.Add(course);

        }

        internal ShoppingCartVM[] GetSelectedCourses(int[] cartIds)
        {
            return courses
                .Where(c => cartIds.Contains(c.Id))
                .Select(c => new ShoppingCartVM
                {
                    Category = c.Category,
                    Price = c.Price,
                    Name = c.Name,
                    Id = c.Id,
                    ImgAlt = c.ImgAlt,
                    ImgName = c.ImgName
                })
                .OrderBy(c => c.Name)
                .ToArray();
        }
        public string GetCourseName(int id)
        {
            return courses.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();

        }

        
    }
}
