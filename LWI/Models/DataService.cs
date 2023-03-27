using System.Linq;
using LWI.Views.Lwi;
using Microsoft.AspNetCore.Identity;

namespace LWI.Models
{
    public class DataService
    {
        //UserManager<DataService> userManager;
        //IHttpContextAccessor httpContextAccessor;
        //List<Course> shoppingBag;
        //public DataService(IHttpContextAccessor httpContextAccessor, UserManager<DataService> userManager)
        //{
        //    this.httpContextAccessor = httpContextAccessor;
        //    this.userManager = userManager;
        //    shoppingBag = new List<Course>();
            
        //}

        List<Course> courses = new List<Course>()
        {
            new Course() 
            {
                Id = 1, 
                Name = "Pontus lilla röda",
                DescriptionShort = "Lär dig allt du behöver veta för att skapa din egna revolution",
                DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
                ImgName = "Csharp.png",
                ImgAlt = "blabla",
                Category = "Pontus kurser",
            },
            new Course()
            {
                Id = 2,
                Name = "Grundkurs i C#",
                DescriptionShort = "En grundkurs i det objektorienterade språket C#",
                DescriptionLong = "En grundkurs i det objektorienterade språket C#",
                ImgName = "JS.png",
                ImgAlt = "blabla",
                Category = "Programmering",

            },
			new Course()
			{
				Id = 3,
				Name = "Sortera med Nadine #1",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "ASP.jpg",
				ImgAlt = "blabla",
				Category = "Nadines kurser",
			},new Course()
			{
				Id = 3,
				Name = "Sortera med Nadine #1",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "python.png",
				ImgAlt = "blabla",
				Category = "Nadines kurser",
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
				.SingleOrDefault(c => c.Id == id)
				;
        }

		//internal async void AddToShoppingCart(DetailsVM model)
		//{
		//	string userId = userManager.GetUserId(httpContextAccessor.HttpContext.User);
  //          DataService user = await userManager.FindByIdAsync(userId);
  //          var course = new Course
  //          {
  //              Id = model.Id,
  //              Name = model.Name,
  //              Price = model.Price,
  //              Category = model.Category,
  //              DescriptionLong = model.DescriptionLong,
  //              ImgAlt = model.ImgAlt,
  //              ImgName = model.ImgName
  //          };
  //          user.shoppingBag.Add(course);

		//}

		internal ShoppingCartVM[] GetSelectedCourses()
		{
			return courses
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
	}
}
