namespace SIS.IRunesApp.Controllers
{
    using Data;
    using MvcFramework;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new IRunesDbContext();
        }

        protected IRunesDbContext Db { get; }
    }
}