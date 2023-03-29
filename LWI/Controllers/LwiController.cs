using System.Text.RegularExpressions;
using LWI.Models;
using LWI.Views.Lwi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace LWI.Controllers
{
	public class LwiController : Controller
	{
        IHttpContextAccessor Accessor;
        DataService dataService;
        StateService stateService;
        public LwiController(DataService dataService, IHttpContextAccessor accessor)
        {
            this.dataService = dataService;
			Accessor = accessor;
            this.stateService = new StateService(Accessor);
		}
		[HttpGet("")]
        public IActionResult Index()
        {
			ViewBag.NoOfItems = stateService.NoOfCartItems();
			return View();
        }

        [HttpGet("/Catalog")]
        public IActionResult Catalog()
        {
			ViewBag.NoOfItems = stateService.NoOfCartItems();
			CatalogVM[] model = dataService.GetAllCourses();
            return View(model);
        }

        [HttpGet("Catalog/Details/{id}")]
        public IActionResult Details(int id)
        {

			var cookieCheck = Request.Cookies["ShoppingCart"];
			if (cookieCheck == null)
				Response.Cookies.Append("ShoppingCart", ",");

            bool itemInCart = stateService.GetCartIds().Contains(id);


            ViewBag.NoOfItems = stateService.NoOfCartItems();
			DetailsVM model = dataService.GetCourse(id);
            model.InCart = itemInCart;

            return View(model);
        }

        [HttpPost("Catalog/Details/{id}")]
        public IActionResult Details(DetailsVM model)
        {
            


            var cookieCheck = Request.Cookies["ShoppingCart"];

            if (cookieCheck == null)
                Response.Cookies.Append("ShoppingCart", ",");
            else if (cookieCheck == ",")
                Response.Cookies.Append("ShoppingCart", $",{model.Id}");
            else
            {
                if (!stateService.GetCartIds().Contains(model.Id))
                    Response.Cookies.Append("ShoppingCart", $"{cookieCheck},{model.Id}");
            }
            return Ok();
        }


        [HttpGet("/ShoppingCart")]
        public IActionResult ShoppingCart()
        {
			ViewBag.NoOfItems = stateService.NoOfCartItems();
            int[] cartIds = stateService.GetCartIds();
			ShoppingCartVM[] model = dataService.GetSelectedCourses(cartIds);
            return View(model);
        }

        [Route("/RemoveFromCart/{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            stateService.RemoveFromCart(id);
            return RedirectToAction(nameof(ShoppingCart));
        }



        [HttpGet("/ShoppingCart/Checkout")]
        public IActionResult Checkout()
        {
			ViewBag.NoOfItems = stateService.NoOfCartItems();
			return View();
        }

        [HttpGet("/ShoppingCart/Checkout/Success")]
        public IActionResult PaymentSuccess()
        {
			return View();
        }
	}
}
