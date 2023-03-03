using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

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
            var favoriteList = favoriteStorage.GetAll(Constants.UserId);
            var favorite = favoriteList.Select(x => x.Product).ToList().ToProductsViewModel();
            return View(favorite);
        }

        // GET: FavoriteController/Create
        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            favoriteStorage.Add(Constants.UserId, product);
            return RedirectToAction("index");
        }

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(Guid productId)
        {
            favoriteStorage.Remove(Constants.UserId, productId);
            return RedirectToAction("index");
        }
    }
}
