using System.Linq;
using System.Web.Mvc;

namespace _2.TODOList.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new TaskDbContext())
                return View(db.Tasks.ToList());
        }
    }
}
