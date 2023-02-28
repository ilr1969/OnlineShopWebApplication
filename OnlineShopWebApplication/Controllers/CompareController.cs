using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class CompareController : Controller
    {
        public IProductStorage productStorage;
        private readonly ToViewModelConverter toViewModelConverter;

        public CompareController(IProductStorage productStorage, ToViewModelConverter toViewModelConverter)
        {
            this.productStorage = productStorage;
            this.toViewModelConverter = toViewModelConverter;
        }

        public static List<ProductViewModel> compareList = new List<ProductViewModel>();
        // GET: CompareController
        public ActionResult Index()
        {
            return View(compareList);
        }

        public ActionResult Add(Guid productId)
        {
            var product = toViewModelConverter.ProductToViewModel(productStorage.TryGetById(productId));
            if (!compareList.Contains(product))
            {
                compareList.Add(product);
            }
            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            compareList.Remove(toViewModelConverter.ProductToViewModel(product));
            return RedirectToAction("index");
        }
    }
}
