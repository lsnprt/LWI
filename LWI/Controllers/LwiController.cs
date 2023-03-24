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
        public IActionResult Catalog()
        {
            CatalogVM[] model = dataService.GetAllCourses();
            return View(model);
        }

		[HttpGet("/Details/{id}")]
		public IActionResult Details(int id)
		{
			DetailsVM model = dataService.GetCourse(id);
			return View(model);
		}

		[HttpPost("/Details/{id}")]
		public IActionResult Details(DetailsVM model)
		{
            dataService.AddToShoppingCart(model);
            return RedirectToAction(nameof(Details));
		}


		[HttpGet("/ShoppingCart")]
		public IActionResult ShoppingCart()
		{
			ShoppingCartVM[] model = dataService.GetSelectedCourses();
			return View(model);
		}
	}
}
