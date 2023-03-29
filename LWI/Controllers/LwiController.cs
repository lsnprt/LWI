using LWI.Models;
using LWI.Views.Lwi;
using Microsoft.AspNetCore.Mvc;

namespace LWI.Controllers
{
	public class LwiController : Controller
	{
		DataService dataService;
		public LwiController(DataService dataService)
		{
			this.dataService = dataService;
		}
		[HttpGet("")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("/Catalog")]
		public IActionResult Catalog(string category)
		{
			CatalogVM[] model = dataService.GetAllCourses();
			var filteredCourses = model;
			if (!string.IsNullOrEmpty(category))
			{
				filteredCourses = filteredCourses.Where(p => p.Category == category).ToArray();
			}
			ViewBag.Categories = model.Select(p => p.Category).Distinct().ToList();
			//ViewBag.PriceRanges = new List<string> { "Free", "1000 to 1500", "over 1500" };
			return View(filteredCourses);
		}

		[HttpGet("/Details/{id}")]
		public IActionResult Details(int id)
		{
			DetailsVM model = dataService.GetCourse(id);
			return View(model);
		}

		//[HttpPost("/Details/{id}")]
		//public IActionResult Details(DetailsVM model)
		//{
		//          dataService.AddToShoppingCart(model);
		//          return RedirectToAction(nameof(Details));
		//}


		[HttpGet("/ShoppingCart")]
		public IActionResult ShoppingCart()
		{
			ShoppingCartVM[] model = dataService.GetSelectedCourses();
			return View(model);
		}

		[HttpGet("/ShoppingCart/Checkout")]
		public IActionResult Checkout()
		{
			return View();
		}

		[HttpGet("/ShoppingCart/Checkout/Success")]
		public IActionResult PaymentSuccess()
		{
			return View();
		}
	}
}
