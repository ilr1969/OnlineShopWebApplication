using Microsoft.AspNetCore.Http;
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

        public ActionResult Add(int productId)
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

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
