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
        public IActionResult Index(int productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }
    }
}
