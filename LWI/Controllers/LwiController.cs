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

            var cookieCheck = Request.Cookies["ShoppingCart"];
            if (cookieCheck == null)
                Response.Cookies.Append("ShoppingCart", ",");

            bool itemInCart = stateService.GetCartIds().Contains(id);


            ViewBag.NoOfItems = stateService.NoOfCartItems();
            DetailsVM model = dataService.GetCourse(id);
            //model.InCart = itemInCart;

            return View(model);
        }

        [HttpPost("Catalog/Details/{id}")]
        public IActionResult Details(DetailsVM model)
        {

            var cookieCheck = Request.Cookies["ShoppingCart"];

            if (cookieCheck == ",")
            {
                Response.Cookies.Append("ShoppingCart", $",{model.Id}");
                return Ok(new
                {
                    message = $"La till '{dataService.GetCourseName(model.Id)}' i varukorgen!",
                    ImgUrl = "/Photos_and_Icons/CARTMASTAH.jpg",
                    Item = 1,
                });
            }
            else if (stateService.GetCartIds().Contains(model.Id))
            {
                return Ok(new
                {
                    message = $"'{dataService.GetCourseName(model.Id)}' finns redan i din varukorg!",
                    ImgUrl = "/Photos_and_Icons/RealSadCart.PNG",
                    Item = 0,
                });
            }
            else
            {
                Response.Cookies.Append("ShoppingCart", $"{cookieCheck},{model.Id}");
                return Ok(new
                {
                    message = $"La till '{dataService.GetCourseName(model.Id)}' i varukorgen!",
                    ImgUrl = "/Photos_and_Icons/CARTMASTAH.jpg",
                    Item = 1,
                });
            }
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
            return RedirectToAction(nameof(ShoppingCartAsync));
        }

        [HttpGet("/ShoppingCart/Checkout")]
        public IActionResult Checkout()
        {
            int[] cartIds = stateService.GetCartIds();
            CheckoutVM model = dataService.GetCheckoutVM(cartIds);
            return View(model);
        }

        [HttpPost("/ShoppingCart/Checkout")]
        public async Task<IActionResult> CheckoutAsync(CheckoutVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            int[] checkoutItemsIds = stateService.GetCartIds();
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

