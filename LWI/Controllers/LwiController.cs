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
            var cookieCheck = Request.Cookies["ShoppingCart"];

            if (cookieCheck == null)
                Response.Cookies.Append("ShoppingCart", "");
            else if (cookieCheck == "")
                Response.Cookies.Append("ShoppingCart", $"{model.Id}");
            else
                Response.Cookies.Append("ShoppingCart", $"{cookieCheck},{model.Id}");

            TempData["Message"] = $"Lyckades att lägga till " +
            $"{dataService.GetCourseName(model.Id)} i din varukorg";

            return RedirectToAction(nameof(Details));
        }


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
