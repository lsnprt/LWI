using LWI.Models;
using LWI.Views.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LWI.Controllers
{
    public class AccountController : Controller
    {
        DataService dataService;
        AccountService account;
        IHttpContextAccessor accessor;
        public AccountController(AccountService account, IHttpContextAccessor context, DataService service)
        {
            this.account = account;
            this.accessor = context;
            this.dataService = service;
        }

        [Authorize]
        [HttpGet("/account")]
        public async Task<IActionResult> AccountHomepageAsync()
        {
            return View();
        }

        [Authorize]
        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("/logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await account.Logout();
            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        [HttpGet("/addcourse")]
        public IActionResult AddCourse()
        {
            return View();
        }

        [Authorize]
        [HttpPost("/addcourse")]
        public async Task<IActionResult> AddCourseAsync(AddCourseVM model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            string userId = account.getUserIdString();

            await dataService.AddCourseAsync(model, userId);
            return RedirectToAction(nameof(MyCoursesAsync).Replace("Async", string.Empty));
        }

        [Authorize]
        [HttpGet("/mycourses")]
        public async Task<IActionResult> MyCoursesAsync(MyCoursesVM[] model)
        {
            string userId = account.getUserIdString();
            model = await dataService.getMyCoursesVMAsync(userId);
            return View(model);
        }
    }
}
