using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels.Users;
using SULS.Models;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            if (this.User != null)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            User userFromDb = this.userService.GetUserByUsernameAndPassword(model.Username, model.Password);

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            this.userService.CreateUser(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }

        
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}