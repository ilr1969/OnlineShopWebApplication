using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public ICartStorage cartStorage;
        public IOrderStorage orderStorage;
        private readonly UserManager<User> userManager;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, UserManager<User> userManager)
        {
            this.cartStorage = cartStorage;
            this.orderStorage = orderStorage;
            this.userManager = userManager;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // GET: OrderController/Success
        public ActionResult Success(OrderDeliveryInfoViewModel orderDeliveryInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    DeliveryInfo = orderDeliveryInfoViewModel.ToOrderDeliveryInfo(),
                    CartItems = cartStorage.TryGetByUserId(userManager.GetUserId(HttpContext.User)).CartItems,
                    UserName = userManager.GetUserAsync(HttpContext.User).Result.UserName
                };

                orderStorage.Add(order);
                cartStorage.ClearBasket(userManager.GetUserId(HttpContext.User));
                return View();
            }
            ModelState.AddModelError("Error", "Заполните все поля");
            return View("Index", orderDeliveryInfoViewModel);
        }

        public IActionResult Detail(int orderNumber)
        {
            var order = orderStorage.TryGetByNumber(orderNumber).ToOrderViewModel();
            return View(order);
        }
    }
}
