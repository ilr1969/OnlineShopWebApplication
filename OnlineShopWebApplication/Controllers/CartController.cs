using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly ICartStorage cartStorage;
        public CartController(IProductStorage productStorage, ICartStorage cartStorage)
        {
            this.productStorage = productStorage;
            this.cartStorage = cartStorage;
        }
        // GET: CartController
        public ActionResult Index()
        {
            var cart = cartStorage.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public ActionResult Add(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            cartStorage.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        // GET: CartController/ChangeCount(int count, string product)
        public ActionResult ChangeCount(int count, string product)
        {
            cartStorage.ChangeCount(count, product);
            return RedirectToAction("Index");
        }

        // GET: CartController/Clear
        public ActionResult Clear()
        {
            cartStorage.ClearBasket();
            return RedirectToAction("Index");
        }
    }
}
