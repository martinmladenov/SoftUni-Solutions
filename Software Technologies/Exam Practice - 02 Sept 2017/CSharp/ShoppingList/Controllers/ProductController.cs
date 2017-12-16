using ShoppingList.Models;
using System.Linq;
using System.Web.Mvc;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                return View(db.Products.ToList());
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
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            using (var db = new ShoppingListDbContext())
            {
                db.Products.Add(product);
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

            using (var db = new ShoppingListDbContext())
            {
                var film = db.Products.Find(id);
                if (film == null)
                    return RedirectToAction("Index");

                return View(film);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            if (id == null || !ModelState.IsValid)
                return View("Edit", productModel);

            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products.Find(id);
                if (product == null)
                    return View("Edit", productModel);

                product.Name = productModel.Name;
                product.Priority = productModel.Priority;
                product.Quantity = productModel.Quantity;
                product.Status = productModel.Status;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
