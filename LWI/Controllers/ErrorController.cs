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
    }
}
