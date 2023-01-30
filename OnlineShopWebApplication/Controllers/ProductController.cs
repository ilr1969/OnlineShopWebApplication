using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        public ProductController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        // GET: ProductController
        public IActionResult Index(int ID)
        {
            var product = productStorage.TryGetById(ID);
            return View(product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
