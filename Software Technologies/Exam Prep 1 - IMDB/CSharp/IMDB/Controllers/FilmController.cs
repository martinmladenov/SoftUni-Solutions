using IMDB.Models;
using System.Linq;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new IMDBDbContext())
            {
                return View(db.Films.ToList());
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
        public ActionResult Create(Film film)
        {
            if (!ModelState.IsValid)
                return View();

            using (var db = new IMDBDbContext())
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(id);
                if (film == null)
                    return RedirectToAction("Index");

                return View(film);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (!ModelState.IsValid)
                return View("Edit", filmModel);

            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(filmModel.Id);
                if (film == null)
                    return View("Edit", filmModel);

                film.Name = filmModel.Name;
                film.Director = filmModel.Director;
                film.Genre = filmModel.Genre;
                film.Year = filmModel.Year;

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

            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(id);
                if (film == null)
                    return RedirectToAction("Index");

                return View(film);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(filmModel.Id);
                if (film == null)
                    return RedirectToAction("Index");

                db.Films.Remove(film);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
