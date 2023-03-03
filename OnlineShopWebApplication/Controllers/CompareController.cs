using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Controllers
{
    public class CompareController : Controller
    {
        public IProductStorage productStorage;
        private readonly ICompareStorage compareStorage;

        public CompareController(IProductStorage productStorage, ICompareStorage compareStorage)
        {
            this.productStorage = productStorage;
            this.compareStorage = compareStorage;
        }

        // GET: CompareController
        public ActionResult Index()
        {
            var compareList = compareStorage.GetAll(Constants.UserId);
            return View(compareList.ToProductsViewModel());
        }

        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            compareStorage.Add(Constants.UserId, product);
            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid productId)
        {
            compareStorage.Remove(Constants.UserId, productId);
            return RedirectToAction("index");
        }
    }
}
