using LWI.Models;
using LWI.Views.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace LWI.Controllers
{
    public class AccountController : Controller
    {
        AccountService account;
        IHttpContextAccessor accessor;
        public AccountController(AccountService account, IHttpContextAccessor context)
        {
            this.account = account;
            this.accessor = context;
        }

        [Authorize]
        [HttpGet("/account")]
        public async Task<IActionResult> AccountHomepageAsync()
        {
            return View();
        }

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateAsync(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string result = await account.CreateAccount(model);

            if (result != null)
            {
                return RedirectToAction(nameof(ErrorController.ProcedureError), nameof(ErrorController).Replace("Controller", string.Empty));
            }
         
            return RedirectToAction(nameof(AccountHomepageAsync).Replace("Async", string.Empty));
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> LoginAsync(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string result = await account.TryLoginAsync(model);

            if (result != null)
            {
                ModelState.AddModelError(string.Empty, result);
                return View();
            }

            return RedirectToAction(nameof(AccountHomepageAsync).Replace("Async", string.Empty));
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await account.Logout();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet("/addcourse")]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost("/addcourse")]
        public async Task<IActionResult> AddCourseAsync(AddCourseVM model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            await account.AddCourseAsync(model);
            return View();
        }
    }
}
