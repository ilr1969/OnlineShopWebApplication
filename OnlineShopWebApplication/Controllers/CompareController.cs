using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShop.Database.Storages;
using OnlineShopWebApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<Product> compareList;
            if (HttpContext.User.Identity.Name == null && Request.Cookies.ContainsKey("TempUser"))
            {
                var tempUserId = Request.Cookies["TempUser"];
                compareList = compareStorage.GetAll(tempUserId);
            }
            else
            {
                compareList = compareStorage.GetAll(userManager.GetUserId(HttpContext.User));
            }
            return View(compareList.ToProductsViewModel());
        }

        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            if (HttpContext.User.Identity.Name == null)
            {
                if (Request.Cookies.ContainsKey("TempUser"))
                {
                    var tempUserId = Request.Cookies["TempUser"];
                    Response.Cookies.Append("TempUser", tempUserId);
                    compareStorage.Add(tempUserId, product);
                }
                else
                {
                    var tempUserId = Guid.NewGuid().ToString();
                    Response.Cookies.Append("TempUser", tempUserId);
                    compareStorage.Add(tempUserId, product);
                }
            }
            else
            {
                compareStorage.Add(userManager.GetUserId(HttpContext.User), product);
            }
            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid productId)
        {
            if (HttpContext.User.Identity.Name == null)
            {
                var tempUserId = Request.Cookies["TempUser"];
                compareStorage.Remove(tempUserId, productId);
            }
            else
            {
                compareStorage.Remove(userManager.GetUserId(HttpContext.User), productId);
            }
            return RedirectToAction("index");
        }
    }
}
