using Microsoft.AspNetCore.Identity;

namespace LWI.Models
{
    public class AccountService
    {
        UserManager<CourseCreator> userManager;
        SignInManager<CourseCreator> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountService(UserManager<CourseCreator> userManager,
        SignInManager<CourseCreator> signInManager,
        RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<string> CreateAccount()
        {
            var user = new CourseCreator
            {
                UserName = "PH",
                FirstName = "Pontus",
                LastName = "Höglund",
                Occupation = "MVC application developer",
                Description = "27 år gammal och bor i Skellefteå, tyvärr"
            };
            IdentityResult result = await userManager.CreateAsync(user, "Hej_123");
            bool wasUserCreated = result.Succeeded;
            if(wasUserCreated)
            {
                return "Din användare har skapats!";
            }
            else
            {
                return "Din användare skapades inte!";
            }
        }
    }
}
