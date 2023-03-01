using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class CompareController : Controller
    {
        public IProductStorage productStorage;
        private readonly ICompareStorage compareStorage;
        private readonly ToViewModelConverter toViewModelConverter;

        public CompareController(IProductStorage productStorage, ToViewModelConverter toViewModelConverter, ICompareStorage compareStorage)
        {
            this.productStorage = productStorage;
            this.toViewModelConverter = toViewModelConverter;
            this.compareStorage = compareStorage;
        }

        // GET: CompareController
        public ActionResult Index()
        {
            var compareList = compareStorage.TryGetById(Constants.UserId);
            var productsCompareList = compareList.CompareItems.Select(x => x.Product).ToList();
            return View(toViewModelConverter.ProductsToViewModel(productsCompareList));
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
