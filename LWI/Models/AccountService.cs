using LWI.Views.Account;
using Microsoft.AspNetCore.Identity;

namespace LWI.Models
{

    public class AccountService
    {
        ApplicationContext context;

        UserManager<CourseCreator> userManager;
        SignInManager<CourseCreator> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountService(UserManager<CourseCreator> userManager,
        SignInManager<CourseCreator> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }
        public async Task<string> CreateAccount(CreateVM model)
        {
            var user = new CourseCreator
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Occupation = model.Profession,
                Description = model.Description
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            return result.Succeeded ? null : "Ditt konto kunde inte skapas :( ";
        }

        internal Task AddCourseAsync(AddCourseVM model)
        {
            context.Courses
                .Add(
                new Course
                {
                    Name = model.Name,
                    Price = model.Price,
                    ImgName = "isam.png",
                    ImgAlt = "Hetaste utvecklaren in town",
                    IsEco = model.IsEco,
                    Category = model.Category,
                    DescriptionLong = model.DescriptionLong,
                    DescriptionShort = model.DescriptionShort,


                }
                );

            return Task.CompletedTask;
        }

        internal async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        internal async Task<string> TryLoginAsync(LoginVM model)
        {
            SignInResult result = await signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                isPersistent: false,
                lockoutOnFailure: false
                );

            return result.Succeeded ? null : "Fel användarnamn eller lösenord";
        }
    }
}
