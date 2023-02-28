using System;
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
            var favoriteList = favoriteStorage.GetAll();
            return View(favoriteList);
        }

        // GET: FavoriteController/Create
        public ActionResult Add(Guid productId)
        {
            var favoriteList = favoriteStorage.GetAll();
            var product = productStorage.TryGetById(productId);
            if (!favoriteList.Contains(toViewModelConverter.ProductToViewModel(product)))
            {
                favoriteList.Add(toViewModelConverter.ProductToViewModel(product));
            }
            return RedirectToAction("index");
        }

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(Guid productId)
        {
            var favoriteList = favoriteStorage.GetAll();
            var product = productStorage.TryGetById(productId);
            favoriteList.Remove(toViewModelConverter.ProductToViewModel(product));
            return RedirectToAction("index");
        }
    }
}
