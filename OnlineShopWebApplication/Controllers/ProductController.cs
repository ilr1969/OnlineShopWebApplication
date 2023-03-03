using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

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
        public IActionResult Index(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product.ToProductViewModel());
        }
    }
}
