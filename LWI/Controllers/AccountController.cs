using LWI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LWI.Controllers
{
    public class AccountController : Controller
    {
        AccountService account;
        public AccountController(AccountService account)
        {
            this.account = account;
        }

        [HttpGet("/account")]
        public async Task<IActionResult> AccountHomepage()
        {
            return View();
        }

        [HttpGet("/create")]
        public async Task<IActionResult> Create()
        {
            var hej = await account.CreateAccount();
            return Content(hej);
        }

        [HttpGet("/login")]
        public async Task<IActionResult> Login()
        {

            return View();
        }
        [HttpPost("/login")]

        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
