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
        private readonly ToViewModelConverter toViewModelConverter;

        public FavoriteController(IProductStorage productStorage, IFavoriteStorage favoriteStorage, ToViewModelConverter toViewModelConverter)
        {
            this.productStorage = productStorage;
            this.favoriteStorage = favoriteStorage;
            this.toViewModelConverter = toViewModelConverter;
        }
        // GET: FavoriteController
        public ActionResult Index()
        {
            var favoriteList = favoriteStorage.TryGetById(Constants.UserId).FavoriteItems;
            var favorite = toViewModelConverter.ProductsToViewModel(favoriteList.Select(x => x.Product).ToList());
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
