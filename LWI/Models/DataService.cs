using System.Data.SqlTypes;
using System.Linq;
using LWI.Views.Lwi;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    ImgName = c.ImgName,
                    Teacher=c.Teacher
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

        public async Task<int> ProcessPayment(CheckoutVM model, int[] cartIds)
        {
            var newOrder = await context.Orders.AddAsync(new Order
            {
                OrderDate = DateTime.Now,
                Total = model.Total,
                CCNumber = model.CCNumber.Substring(model.CCNumber.Length - 4),
                CCHolder = model.CCHolder,
                Email = model.Email,
                Address = model.Address,
                City = model.City,
                ZipCode = model.ZipCode,
                Country = model.Country,
                OrdersToCourses = new List<OrdersToCourses>()
            });

            foreach (int id in cartIds)
            {
                newOrder.Entity.OrdersToCourses.Add(new OrdersToCourses { 
                CourseId = id,
                OrderId = newOrder.Entity.Id
                });
            }

            context.SaveChanges();
            return newOrder.Entity.Id;
        }

        internal CheckoutVM GetCheckoutVM(int[] cartIds)
        {
            return new CheckoutVM
            {
                CourseIdsCount = cartIds.Count(),

                Total = context
              .Courses
              .Where(c => cartIds.Contains(c.Id))
              .Select(c => c.Price)
              .Sum()
            };
        }

        internal async Task<PaymentSuccessVM> GetPaymentSuccessVMAsync(int id)
        {
            var order = await context
                .Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) 
            {
                return null;
            }

            return new PaymentSuccessVM
            {
                OrderNumber = order.Id,
                CustomerEmail = order.Email,
                CustomerName = order.CCHolder
            };
        }
    }
}
