namespace PANDA.App.Controllers
{
    using System.Collections.Generic;
    using Models;
    using PANDA.Models;
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;
    using SIS.Framework.Security;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        
        public IActionResult Login()
        {
            if (this.Identity != null)
            {
                return this.RedirectToAction("/");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (this.Identity != null)
            {
                return this.RedirectToAction("/");
            }

            var user = this.usersService.Get(model.Username, model.Password);

            if (user == null)
            {
                return this.View();
            }

            var roles = new List<string> {"User"};

            if (user.Role == Role.Admin)
            {
                roles.Add("Admin");
            }

            this.SignIn(new IdentityUser
            {
                Username = user.Username,
                Email = user.Email,
                Roles = roles
            });

            return this.RedirectToAction("/");
        }

        public IActionResult Register()
        {
            if (this.Identity != null)
            {
                return this.RedirectToAction("/");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (this.Identity != null)
            {
                return this.RedirectToAction("/");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.View();
            }

            var user = this.usersService.Create(model.Username, model.Password, model.Email);

            if (user == null)
            {
                return this.View();
            }

            var roles = new List<string> {"User"};

            if (user.Role == Role.Admin)
            {
                roles.Add("Admin");
            }

            this.SignIn(new IdentityUser
            {
                Username = user.Username,
                Email = user.Email,
                Roles = roles
            });

            return this.RedirectToAction("/");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.RedirectToAction("/");
        }
    }
}