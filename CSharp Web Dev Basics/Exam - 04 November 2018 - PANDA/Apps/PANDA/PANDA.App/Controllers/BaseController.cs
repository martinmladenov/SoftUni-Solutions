namespace PANDA.App.Controllers
{
    using System.Linq;
    using System.Runtime.CompilerServices;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Controllers;

    public abstract class BaseController : Controller
    {
        protected override IViewable View([CallerMemberName] string actionName = "")
        {
            if (this.Identity == null)
            {
                this.Model["IsGuest"] = "block";
                this.Model["IsUser"] = "none";
                this.Model["IsAdmin"] = "none";
                this.Model["IsNotAdmin"] = "none";
            }
            else
            {
                this.Model["IsGuest"] = "none";
                this.Model["IsUser"] = "block";
                this.Model["Username"] = this.Identity.Username;

                if (this.Identity.Roles.Contains("Admin"))
                {
                    this.Model["IsAdmin"] = "block";
                    this.Model["IsNotAdmin"] = "none";
                }
                else
                {
                    this.Model["IsAdmin"] = "none";
                    this.Model["IsNotAdmin"] = "block";
                }
            }

            return base.View(actionName);
        }
    }
}