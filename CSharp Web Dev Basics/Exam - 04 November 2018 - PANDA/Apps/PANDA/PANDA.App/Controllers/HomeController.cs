namespace PANDA.App.Controllers
{
    using Services.Contracts;
    using SIS.Framework.ActionResults;

    public class HomeController : BaseController
    {
        private IPackagesService packagesService;

        public HomeController(IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        public IActionResult Index()
        {
            if (this.Identity != null)
            {
                var pending = this.packagesService.GetPendingForUser(this.Identity.Username);
                var shipped = this.packagesService.GetShippedForUser(this.Identity.Username);
                var delivered = this.packagesService.GetDeliveredForUser(this.Identity.Username);

                this.Model["PendingPackages"] = pending;
                this.Model["ShippedPackages"] = shipped;
                this.Model["DeliveredPackages"] = delivered;
            }

            return this.View();
        }
    }
}
