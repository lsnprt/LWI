using LWI.Views.Lwi;
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
				Name = "Bli en glad pappa",
				Teacher = "Nils",
				DescriptionShort = "Med oss ska du lära dig att tvätta, diska, mata och byta blöjor.",
				DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
				ImgName = "hecan.png",
				ImgAlt = "glad pappa kurs",
				Category = "Hållbarhet",
				Price =0
			},
			new Course()
			{
				Name = "Lar dig JS.",
				Teacher = "Pontus",
				DescriptionShort = "Lär dig JS mest älskade programmering språk i planeten.",
				DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
				ImgName = "JS.png",
				ImgAlt = "JS course",
				Category = "Programming",
				Price = 3999
			},new Course()
			{
				Name = "Arabiska for Swedes.",
				Teacher = "Isam",
				DescriptionShort = "Tala Arabiska som om du kommer ifrån mitt i Syrien.",
				DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
				ImgName = "Arabiska.jpg",
				ImgAlt = "Arabiska course",
				Category = "Languages",
				Price = 1999
			},new Course()
			{
				Name = "Franska for Swedes.",
				Teacher = "Nadine",
				DescriptionShort = "Tala Arabiska som om du kommer ifrån mitt i Paris.",
				DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
				ImgName = "Franska.png",
				ImgAlt = "Franska course",
				Category = "Languages",
				Price = 1999
			},
			new Course()
			{
				Name = "Bästa C# kurs bara i 48 månader.",
				Teacher = "Pontus",
				DescriptionShort = "Lär dig de första några stegen i c#.",
				DescriptionLong = "Lär dig allt du behöver veta för att skapa din egna revolution",
				ImgName = "Csharp.png",
				ImgAlt = "Csharp course",
				Category = "Programming",
				Price = 1999
			},
			new Course()
			{
				Name = "Database and relational illusion of new world order.",
				Teacher = "Isam",
				DescriptionShort = "An introduction to your new journey to the bottom of hollow.",
				DescriptionLong = "Bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
				ImgName = "Great_Seal_of_the_United_States_(reverse).svg.png",
				ImgAlt = "new world order pic",
				Category = "Database",
				Price = 9999

			},
			new Course()
			{
				Name = "Sortera med Nadine #1",
				Teacher = "Alessandro",
				DescriptionShort = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				DescriptionLong = "I Nadines första sorteringskurs lär vi oss hur man sorterar papper",
				ImgName = "Källsortering(1).png",
				ImgAlt = "blabla",
				Category = "Hållbarhet",
				Price = 1999
			},new Course()
			{

				Name = "Sortera med Nadine #2",
				Teacher="Alessandro",
				DescriptionShort = "I Nadines andra sorteringskurs lär vi oss hur man sorterar tegel",
				DescriptionLong = "I Nadines andra sorteringskurs lär vi oss hur man sorterar tegel",
				ImgName = "Källsortering(2).png",
				ImgAlt = "blabla",
				Category = "Hållbarher",
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
					Price = c.Price.ToString("0.00 SEK"),
					Name = c.Name,
					Id = c.Id,
					DescriptionShort = c.DescriptionShort,
					ImgAlt = c.ImgAlt,
					ImgName = c.ImgName,
					Teacher = c.Teacher,
					IsEco = c.IsEco
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
					Price = c.Price.ToString("0.00 SEK"),
					Name = c.Name,
					Id = c.Id,
					DescriptionLong = c.DescriptionLong,
					ImgAlt = c.ImgAlt,
					ImgName = c.ImgName,
					IsEco = c.IsEco
				})
				.FirstOrDefault(c => c.Id == id)
				;
		}

		//internal void AddToShoppingCart(DetailsVM model)
		//{
		//    var course = courses.Where(o => o.Id == model.Id).FirstOrDefault();
		//    shoppingBag.Add(course);
		//}

		public async Task<ShoppingCartVM> GetShoppingCartVMAsync(int[] cartIds)
		{
			var total = await context.Courses
				.Where(c => cartIds.Contains(c.Id))
				.Select(c => c.Price).SumAsync();

			var vm = new ShoppingCartVM
			{
				ItemCount = cartIds.Length,
				Total = total.ToString("0.00 SEK"),

				shoppingCartItemVMs = await context
				.Courses
				.Where(c => cartIds.Contains(c.Id))
				.Select(c => new ShoppingCartItemVM
				{
					Id = c.Id,
					Name = c.Name,
					Price = c.Price.ToString("0.00 SEK"),
					Category = c.Category,
					ImgAlt = c.ImgAlt,
					ImgName = c.ImgName,
					IsEco = c.IsEco
				}).ToArrayAsync()
			};

			return vm;
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
				newOrder.Entity.OrdersToCourses.Add(new OrdersToCourses
				{
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
