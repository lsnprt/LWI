using System.Data.SqlTypes;
using System.Linq;
using LWI.Views.Lwi;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LWI.Models
{
    public class DataService
    {
        ApplicationContext context;

        //List<Course> shoppingBag = new List<Course>();

        public DataService(ApplicationContext context)

        {
            this.context = context;
        }

        

        List<Course> courses = new List<Course>()
        {
            new Course()
            {
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

        internal void InitialiseDB()
        {
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }

        public CatalogVM[] GetAllCourses()
        {
            return context.Courses
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
            return context.Courses
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

        //internal void AddToShoppingCart(DetailsVM model)
        //{
        //    var course = courses.Where(o => o.Id == model.Id).FirstOrDefault();
        //    shoppingBag.Add(course);
        //}

        internal ShoppingCartVM[] GetSelectedCourses(int[] cartIds)
        {
            return context.Courses
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
            return context.Courses.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();

        }

        public void ProcessPayment(CheckoutVM model, int[] cartIds)
        {
            //needs implementation when DBcontext is done
        }

        internal CheckoutVM GetCheckoutVM(int[] cartIds)
        {
            return new CheckoutVM
            {
                Total = context
              .Courses
              .Where(c => cartIds.Contains(c.Id))
              .Select(c => c.Price)
              .Sum()
            };
        }
    }
}
