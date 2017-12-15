using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    using System.Linq;

    [ValidateInput(false)]
    public class TaskController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new TodoListDbContext())
            {
                return View(db.Tasks.ToList());
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
        public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
                return View();

            using (var db = new TodoListDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            using (var db = new TodoListDbContext())
            {
                var task = db.Tasks.Find(id);
                if (task == null)
                    return RedirectToAction("Index");

                return View(task);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            using (var db = new TodoListDbContext())
            {
                var task = db.Tasks.Find(id);
                if (task == null)
                    return RedirectToAction("Index");

                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
