using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class FavoriteController : Controller
    {
        readonly IProductStorage productStorage;
        readonly IFavoriteStorage favoriteStorage;

        public FavoriteController(IProductStorage productStorage, IFavoriteStorage favoriteStorage)
        {
            this.productStorage = productStorage;
            this.favoriteStorage = favoriteStorage;
        }
        // GET: FavoriteController
        public ActionResult Index()
        {
            var favoriteList = favoriteStorage.GetAll();
            return View(favoriteList);
        }

        // GET: FavoriteController/Create
        public ActionResult Add(Guid productId)
        {
            var favoriteList = favoriteStorage.GetAll();
            var product = productStorage.TryGetById(productId);
            if (!favoriteList.Contains(product))
            {
                favoriteList.Add(product);
            }
            return RedirectToAction("index");
        }

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(Guid productId)
        {
            var favoriteList = favoriteStorage.GetAll();
            var product = productStorage.TryGetById(productId);
            favoriteList.Remove(product);
            return RedirectToAction("index");
        }
    }
}
