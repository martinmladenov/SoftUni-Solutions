using System.Web.Mvc;

namespace _17.ASP.NET_Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List", "Article");
        }
    }
}
