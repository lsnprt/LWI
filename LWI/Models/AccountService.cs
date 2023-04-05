using LWI.Views.Account;
using Microsoft.AspNetCore.Identity;

namespace LWI.Models
{

    public class AccountService
    {
        UserManager<CourseCreator> userManager;
        SignInManager<CourseCreator> signInManager;
        RoleManager<IdentityRole> roleManager;
        IHttpContextAccessor accessor;
        ApplicationContext context;

        public AccountService(UserManager<CourseCreator> userManager,
        SignInManager<CourseCreator> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationContext context,
        IHttpContextAccessor accessor)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accessor = accessor;
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

        internal EditProfileVM GetAccount(string userId)
        {
            return context.Users.Where(u => u.Id == userId).Select(u => new EditProfileVM
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Description = u.Description,
                Profession = u.Occupation,
            }).FirstOrDefault();
        }

        internal string getUserIdString()
        {
            return userManager.GetUserId(accessor.HttpContext.User).ToString();
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

        internal async Task<string> UpdateProfile(EditProfileVM model, string userId)
        {
            var user = context.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (model.Profession != null)
                user.Occupation = model.Profession;
            if (model.FirstName != null)
                user.FirstName = model.FirstName;
            if (model.LastName != null)
                user.LastName = model.LastName;
            if (model.Description != null)
                user.Description = model.Description;

            context.SaveChanges();

            return "Ändringarna är genomförda!";

        }
    }
}
