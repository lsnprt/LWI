using Microsoft.AspNetCore.Mvc;

namespace LWI.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("error/exception")]
        public IActionResult ServerError()
        {
            return View();
        }
        [HttpGet("/error/http/{statusCode}")]
        public IActionResult HttpError(int statusCode)
        {
            return View(statusCode);
        }
    }
}
