namespace PANDA.App.Controllers
{
    using System.Linq;
    using Models;
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;

    public class PackagesController : BaseController
    {
        private IPackagesService packagesService;
        private IUsersService usersService;

        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        [Authorize("Admin")]
        public IActionResult Create()
        {
            var users = this.usersService.GetAll();

            this.Model["Users"] = users;

            return this.View();
        }

        [HttpPost]
        [Authorize("Admin")]
        public IActionResult Create(PackageCreateViewModel model)
        {
            var success = this.packagesService.Create(model.Description, model.Weight, model.ShippingAddress, model.Recipient);

            if (!success)
            {
                return this.RedirectToAction("/Packages/Create");
            }

            return this.RedirectToAction("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var package = this.packagesService.Get(id, this.Identity.Username, this.Identity.Roles.Contains("Admin"));

            if (package == null)
            {
                return this.RedirectToAction("/");
            }

            this.Model["Address"] = package.Address;
            this.Model["Status"] = package.Status;
            this.Model["EstimatedDeliveryDate"] = package.EstimatedDeliveryDate;
            this.Model["Weight"] = package.Weight;
            this.Model["Description"] = package.Description;
            this.Model["Recipient"] = package.Recipient;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Pending()
        {
            var packages = this.packagesService.GetAllPending();

            this.Model["Packages"] = packages;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Shipped()
        {
            var packages = this.packagesService.GetAllShipped();

            this.Model["Packages"] = packages;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Delivered()
        {
            var packages = this.packagesService.GetAllDelivered();

            this.Model["Packages"] = packages;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Ship(string id)
        {
            this.packagesService.Ship(id);

            return this.RedirectToAction("/Packages/Pending");
        }

        [Authorize("Admin")]
        public IActionResult Deliver(string id)
        {
            this.packagesService.Deliver(id);

            return this.RedirectToAction("/Packages/Shipped");
        }

        [Authorize]
        public IActionResult Acquire(string id)
        {
            this.packagesService.Acquire(id, this.Identity.Username);

            return this.RedirectToAction("/");
        }
    }
}
