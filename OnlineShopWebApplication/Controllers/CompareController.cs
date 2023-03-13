using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Controllers
{
    public class CompareController : Controller
    {
        public IProductStorage productStorage;
        private readonly ICompareStorage compareStorage;
        private readonly UserManager<User> userManager;

        public CompareController(IProductStorage productStorage, ICompareStorage compareStorage, UserManager<User> userManager)
        {
            this.productStorage = productStorage;
            this.compareStorage = compareStorage;
            this.userManager = userManager;
        }

        // GET: CompareController
        public ActionResult Index()
        {
            var compareList = compareStorage.GetAll(userManager.GetUserId(HttpContext.User));
            return View(compareList.ToProductsViewModel());
        }

        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            compareStorage.Add(userManager.GetUserId(HttpContext.User), product);
            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid productId)
        {
            compareStorage.Remove(userManager.GetUserId(HttpContext.User), productId);
            return RedirectToAction("index");
        }
    }
}
