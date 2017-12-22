namespace LogNoziroh.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ReportController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new LogNozirohDbContext())
            {
                return View(db.Reports.ToList());
            }
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            using (var db = new LogNozirohDbContext())
            {
                var report = db.Reports.Find(id);
                if (report == null)
                    return RedirectToAction("Index");

                return View(report);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            if (!ModelState.IsValid)
                return View();

            using (var db = new LogNozirohDbContext())
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new LogNozirohDbContext())
            {
                var report = db.Reports.Find(id);
                if (report == null)
                    return RedirectToAction("Index");

                return View(report);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Report reportModel)
        {
            using (var db = new LogNozirohDbContext())
            {
                var report = db.Reports.Find(reportModel.Id);
                if (report == null)
                    return RedirectToAction("Index");

                db.Reports.Remove(report);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}