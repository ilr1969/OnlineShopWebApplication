using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Controllers
{
    public class FavoriteController : Controller
    {
        readonly IProductStorage productStorage;
        readonly IFavoriteStorage favoriteStorage;
        readonly UserManager<User> userManager;

        public FavoriteController(IProductStorage productStorage, IFavoriteStorage favoriteStorage, UserManager<User> userManager)
        {
            this.productStorage = productStorage;
            this.favoriteStorage = favoriteStorage;
            this.userManager = userManager;
        }
        // GET: FavoriteController
        public ActionResult Index()
        {
            var favoriteList = favoriteStorage.GetAll(userManager.GetUserId(HttpContext.User));
            var favorite = favoriteList.Select(x => x.Product).ToList().ToProductsViewModel();
            return View(favorite);
        }

        // GET: FavoriteController/Create
        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            favoriteStorage.Add(userManager.GetUserId(HttpContext.User), product);
            return RedirectToAction("index");
        }

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(Guid productId)
        {
            favoriteStorage.Remove(userManager.GetUserId(HttpContext.User), productId);
            return RedirectToAction("index");
        }
    }
}
