using LWI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LWI.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("error/")]
        [HttpGet("/error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            return View(statusCode);
        }

        [HttpGet("/ShoppingCart/Checkout/Error")]
        public IActionResult PaymentError()
        {
            ViewBag.NoOfItems = stateService.NoOfCartItems();
            return View();
        }
    }
}
