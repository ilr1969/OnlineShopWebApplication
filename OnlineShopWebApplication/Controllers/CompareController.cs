using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class CompareController : Controller
    {
        public IProductStorage productStorage;

        public CompareController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public static List<ProductClass> compareList = new List<ProductClass>();
        // GET: CompareController
        public ActionResult Index(int productId)
        {
            return View(compareList);
        }

        public ActionResult Add(int productId)
        {
            var product = productStorage.TryGetById(productId);
            if (!compareList.Contains(product))
            {
                compareList.Add(product);
            }
            return RedirectToAction("index");
        }

        public IActionResult Delete(int productId)
        {
            var product = productStorage.TryGetById(productId);
            compareList.Remove(product);
            return RedirectToAction("index");
        }
    }
}
