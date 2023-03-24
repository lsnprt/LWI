using Microsoft.AspNetCore.Mvc;

namespace LWI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
