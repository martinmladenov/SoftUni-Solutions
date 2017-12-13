using System.Linq;
using System.Web.Mvc;

namespace _17.ASP.NET_Blog.Controllers
{
    using Models;
    using System.Data.Entity;
    using System.Net;

    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Article/List
        public ActionResult List()
        {
            using (var db = new BlogDbContext())
            {
                var articles = db.Articles
                    .Include(a => a.Author)
                    .ToList();
                return View(articles);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (article == null)
                    return HttpNotFound();

                return View(article);
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article)
        {
            if (!ModelState.IsValid)
                return View(article);

            using (var db = new BlogDbContext())
            {
                article.AuthorId = db.Users
                    .First(u => u.UserName == User.Identity.Name)
                    .Id;
                db.Articles.Add(article);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (!IsUserAuthorizedToEdit(article))
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                if (article == null)
                    return HttpNotFound();

                return View(article);
            }
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (!IsUserAuthorizedToEdit(article))
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                if (article == null)
                    return HttpNotFound();

                db.Articles.Remove(article);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .First(a => a.Id == id);

                if (!IsUserAuthorizedToEdit(article))
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                if (article == null)
                    return HttpNotFound();

                var model = new ArticleViewModel();
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;

                return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .FirstOrDefault(a => a.Id == model.Id);

                if (!IsUserAuthorizedToEdit(article))
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                article.Title = model.Title;
                article.Content = model.Content;

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        private bool IsUserAuthorizedToEdit(Article article)
        {
            return User.IsInRole("Admin") || article.IsAuthor(User.Identity.Name);
        }
    }
}
