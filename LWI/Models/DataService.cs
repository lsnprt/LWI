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
				Teacher="Pontus",
				Name = "Pontus lilla röda",
				DescriptionShort = "Lär dig allt du behöver veta för att skapa din egna revolution",
				DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
				ImgName = "Csharp.png",
				ImgAlt = "blabla",
				Category = "Saving Earth",
				Price=1999.99M
			},
			new Course()
			{
				Id = 2,
				Teacher="Isam",
				Name = "Grundkurs i C#",
				DescriptionShort = "En grundkurs i det objektorienterade språket C#",
				DescriptionLong = "En grundkurs i det objektorienterade språket C#",
				ImgName = "JS.png",
				ImgAlt = "blabla",
				Category = "Programming",
				Price=0
			},
			new Course()
			{
				Id = 3,
				Teacher="Nadine",
				Name = "Sortera med Nadine #1",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "ASP.jpg",
				ImgAlt = "blabla",
				Category = "Saving Earth",
				Price=0
			},
			new Course()
			{
				Id = 4,
				Teacher="Nadine",
				Name = "Sortera med Nadine #1",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "python.png",
				ImgAlt = "blabla",
				Category = "Saving Earth",
				Price=1499.99M
			},
			new Course()
			{
				Id = 5,
				Teacher="Pontus",
				//Teacher="Pontus",
				Name = "Pontus lilla röda",
				DescriptionShort = "Lär dig allt du behöver veta för att skapa din egna revolution",
				DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
				ImgName = "Csharp.png",
				ImgAlt = "blabla",
				Category = "Web Development",
				Price=1999.99M
			},
			new Course()
			{
				Id = 6,
				Teacher="Nadine",
				Name = "Grundkurs i C#",
				DescriptionShort = "En grundkurs i det objektorienterade språket C#",
				DescriptionLong = "En grundkurs i det objektorienterade språket C#",
				ImgName = "JS.png",
				ImgAlt = "blabla",
				Category = "Programming",
				Price=0
			},
			new Course()
			{
				Id = 7,
				Teacher="Isam",
				Name = "Sortera med Nadine #1",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "ASP.jpg",
				ImgAlt = "blabla",
				Category = "Web Development",
				Price=0
			},
			new Course()
			{
				Id = 8,
				Teacher="Nadine",
				Name = "Sortera med Nadine #1",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "python.png",
				ImgAlt = "blabla",
				Category = "Saving Earth",
				Price=1399.99M
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
					ImgName = c.ImgName,
					Teacher=c.Teacher
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
