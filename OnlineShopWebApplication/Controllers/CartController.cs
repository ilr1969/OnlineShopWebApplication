using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly ICartStorage cartStorage;
        private readonly ToViewModelConverter toViewModelConverter;
        public CartController(IProductStorage productStorage, ICartStorage cartStorage, ToViewModelConverter toViewModelConverter)
        {
            this.productStorage = productStorage;
            this.cartStorage = cartStorage;
            this.toViewModelConverter = toViewModelConverter;
        }
        // GET: CartController
        public ActionResult Index()
        {
            var cart = cartStorage.TryGetByUserId(Constants.UserId);
            var cartToView = toViewModelConverter.CartToViewModel(cart);
            return View(cartToView);
        }

        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            cartStorage.Add(product, Constants.UserId);
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
