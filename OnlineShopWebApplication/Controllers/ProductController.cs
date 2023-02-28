using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly ToViewModelConverter toViewModelConverter;
        public ProductController(IProductStorage productStorage, ToViewModelConverter toViewModelConverter)
        {
            this.productStorage = productStorage;
            this.toViewModelConverter = toViewModelConverter;
        }
        // GET: ProductController
        public IActionResult Index(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(toViewModelConverter.ProductToViewModel(product));
        }
    }
}
