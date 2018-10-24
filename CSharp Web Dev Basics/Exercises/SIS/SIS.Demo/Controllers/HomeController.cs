namespace SIS.Demo.Controllers
{
    using Framework.ActionResults;
    using Framework.Attributes.Action;
    using Framework.Attributes.Methods;
    using Framework.Controllers;
    using Framework.Security;
    using Services.Contracts;
    using ViewModels;

    public class HomeController : Controller
    {
        private IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        
        public IActionResult Index()
        {
            this.Model["ShowLoginForm"] = this.Identity == null ? "block" : "none";
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel viewModel)
        {
            if (!this.userService.VerifyPassword(viewModel.Username, viewModel.Password))
            {
                return this.RedirectToAction("/");
            }
            
            this.SignIn(new IdentityUser {Username = viewModel.Username, Password = viewModel.Password});
            return this.RedirectToAction("/home/authorized");
        }
        
        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToAction("/");
        }

        [Authorize]
        public IActionResult Authorized()
        {
            this.Model["Username"] = this.Identity.Username;
            return this.View();
        }
    }
}