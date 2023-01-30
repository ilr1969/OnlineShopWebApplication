using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class FavoriteController : Controller
    {
        public static List<ProductClass> favorite = new List<ProductClass>();
        readonly IProductStorage productStorage;

        public FavoriteController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        // GET: FavoriteController
        public ActionResult Index()
        {
            return View(favorite);
        }

        // GET: FavoriteController/Create
        public ActionResult Add(int productId)
        {
            var product = productStorage.TryGetById(productId);
            if (!favorite.Contains(product))
            {
                favorite.Add(product);
            }
            return RedirectToAction("index");
        }

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(int productId)
        {
            var product = productStorage.TryGetById(productId);
            favorite.Remove(product);
            return RedirectToAction("index");
        }
    }
}
