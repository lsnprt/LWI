using LWI.Models;
using LWI.Views.Lwi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Filters;

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
            //Kör en gång för att initialisera DBn med rätt data
            //dataService.InitialiseDB();



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
            DetailsVM model = dataService.GetCourse(id);
            return View(model);
        }

        [HttpPost("Catalog/Details/{id}")]
        public IActionResult Details(DetailsVM model)
        {

            var info = dataService.AddToCookie(model.Id);

            return Ok(info);
        }


        [HttpGet("/ShoppingCart")]
        public async Task<IActionResult> ShoppingCartAsync()
        {
            ViewBag.NoOfItems = stateService.NoOfCartItems();
            int[] cartIds = stateService.GetCartIds();
            ShoppingCartVM model = await dataService.GetShoppingCartVMAsync(cartIds);
            return View(model);
        }

        [Route("/RemoveFromCart/{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            stateService.RemoveFromCart(id);
            return RedirectToAction(nameof(ShoppingCartAsync).Replace("Async", string.Empty));
        }

        [HttpGet("/ShoppingCart/Checkout")]
        public IActionResult Checkout()
        {
            int[] cartIds = stateService.GetCartIds();
            ViewBag.NoOfItems = cartIds.Count();
			CheckoutVM model = dataService.GetCheckoutVM(cartIds);
            return View(model);
        }

        [HttpPost("/ShoppingCart/Checkout")]
        public async Task<IActionResult> CheckoutAsync(CheckoutVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            int[] checkoutItemsIds = stateService.GetCartIds();
			ViewBag.NoOfItems = checkoutItemsIds.Count();
			int orderId = await dataService.ProcessPayment(model, checkoutItemsIds);
            //empty cart from cookies
            return RedirectToAction(nameof(PaymentSuccessAsync).Replace("Async", ""), new { id = orderId });
        }

        [HttpGet("/ShoppingCart/Checkout/Success/{id}")]
        public async Task<IActionResult> PaymentSuccessAsync(int id)
        {
            PaymentSuccessVM model = await dataService.GetPaymentSuccessVMAsync(id);
            if (model == null)
            {
               return RedirectToAction(nameof(ErrorController.PaymentError), nameof(ErrorController).Replace("Controller", ""));
            }

            return View(model);
        }
    }
}

