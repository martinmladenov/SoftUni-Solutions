using _2.TODOList.Models;
using System.Web.Mvc;

namespace _2.TODOList.Controllers
{
    public class TaskController : Controller
    {
        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (task == null)
                return RedirectToAction("Index", "Home");

            using (var db = new TaskDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);

                if (task == null)
                    return RedirectToAction("Index", "Home");

                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
