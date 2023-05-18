using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShop.Database.Storages;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<FavoriteProduct> favoriteList = new ();
            if (HttpContext.User.Identity.Name == null && Request.Cookies.ContainsKey("TempUser"))
            {
                var tempUserId = Request.Cookies["TempUser"];
                favoriteList = favoriteStorage.GetAll(tempUserId);
            }
            else
            {
                favoriteList = favoriteStorage.GetAll(userManager.GetUserId(HttpContext.User));
            }
            var favorite = favoriteList.Select(x => x.Product).ToList().ToProductsViewModel();
            return View(favorite);
        }

        // GET: FavoriteController/Create
        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            if (HttpContext.User.Identity.Name == null)
            {
                if (Request.Cookies.ContainsKey("TempUser"))
                {
                    var tempUserId = Request.Cookies["TempUser"];
                    Response.Cookies.Append("TempUser", tempUserId);
                    favoriteStorage.Add(tempUserId, product);
                }
                else
                {
                    var tempUserId = Guid.NewGuid().ToString();
                    Response.Cookies.Append("TempUser", tempUserId);
                    favoriteStorage.Add(tempUserId, product);
                }
            }
            else
            {
                favoriteStorage.Add(userManager.GetUserId(HttpContext.User), product);
            }
            return RedirectToAction("index");
        }

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(Guid productId)
        {
            if (HttpContext.User.Identity.Name == null)
            {
                var tempUserId = Request.Cookies["TempUser"];
                favoriteStorage.Remove(tempUserId, productId);
            }
            else
            {
                favoriteStorage.Remove(userManager.GetUserId(HttpContext.User), productId);
            }
            return RedirectToAction("index");
        }
    }
}
