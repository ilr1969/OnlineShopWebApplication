using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;
using System;

namespace OnlineShopWebApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly ICartStorage cartStorage;
        private readonly UserManager<User> userManager;
        public CartController(IProductStorage productStorage, ICartStorage cartStorage, UserManager<User> userManager)
        {
            this.productStorage = productStorage;
            this.cartStorage = cartStorage;
            this.userManager = userManager;
        }
        // GET: CartController
        public ActionResult Index()
        {
            Cart cart;
            if (HttpContext.User.Identity.Name == null && Request.Cookies.ContainsKey("TempUser"))
            {
                var tempUserId = Request.Cookies["TempUser"];
                cart = cartStorage.TryGetByUserId(tempUserId);
            }
            else
            {
                cart = cartStorage.TryGetByUserId(userManager.GetUserId(HttpContext.User));
            }
            var cartToView = cart.ToCartViewModel();
            return View(cartToView);
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
                    cartStorage.Add(product, tempUserId);
                }
                else
                {
                    var tempUserId = Guid.NewGuid().ToString();
                    Response.Cookies.Append("TempUser", tempUserId);
                    cartStorage.Add(product, tempUserId);
                }
            }
            else
            {
                cartStorage.Add(product, userManager.GetUserId(HttpContext.User));
            }
            return RedirectToAction("Index");
        }

        // GET: CartController/ChangeCount(int count, string product)
        public ActionResult ChangeCount(string userId, int count, string product)
        {
            cartStorage.ChangeCount(userId, count, product);
            return RedirectToAction("Index");
        }

        // GET: CartController/Clear
        public ActionResult Clear(string userId)
        {
            cartStorage.ClearBasket(userId);
            return RedirectToAction("Index");
        }
    }
}
