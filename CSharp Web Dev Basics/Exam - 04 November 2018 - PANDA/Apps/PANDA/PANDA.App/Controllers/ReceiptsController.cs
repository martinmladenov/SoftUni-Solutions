namespace PANDA.App.Controllers
{
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;

    public class ReceiptsController : BaseController
    {
        private IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var receipts = this.receiptsService.GetAllForUser(this.Identity.Username);

            this.Model["Receipts"] = receipts;

            return this.View();
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var receipt = this.receiptsService.Get(id, this.Identity.Username);

            if (receipt == null)
            {
                return this.RedirectToAction("/Receipts/Index");
            }

            this.Model["Id"] = receipt.Id;
            this.Model["Fee"] = receipt.Fee;
            this.Model["IssuedOn"] = receipt.IssuedOn;
            this.Model["Recipient"] = receipt.Recipient;
            this.Model["Address"] = receipt.Address;
            this.Model["PackageWeight"] = receipt.PackageWeight;
            this.Model["PackageDescription"] = receipt.PackageDescription;

            return this.View();
        }
    }
}
