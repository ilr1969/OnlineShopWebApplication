using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class OrderController : Controller
    {
        public ICartStorage cartStorage;
        public IMemoryProvider memoryProvider;
        public IOrderStorage orderStorage;
        public ToViewModelConverter toViewModelConverter;

        public OrderController(ICartStorage cartStorage, IMemoryProvider memoryProvider, IOrderStorage orderStorage, ToViewModelConverter toViewModelConverter)
        {
            this.cartStorage = cartStorage;
            this.memoryProvider = memoryProvider;
            this.orderStorage = orderStorage;
            this.toViewModelConverter = toViewModelConverter;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // GET: OrderController/Success
        public ActionResult Success(string userId, OrderViewModel order)
        {
            order.userCart = toViewModelConverter.CartToViewModel(cartStorage.TryGetByUserId(userId));
            orderStorage.Add(order);
            memoryProvider.WriteOrderToFile();
            cartStorage.ClearBasket(userId);
            return View();
        }

        public IActionResult Detail(Guid productId)
        {
            var order = orderStorage.GetOrderList().FirstOrDefault(x => x.Id == productId);
            return View(order);
        }

        [HttpPost]
        public IActionResult SaveOrder(Guid productId, OrderStatusViewModel status)
        {
            orderStorage.ChangeOrderStatus(productId, status);
            var order = orderStorage.GetOrderList().FirstOrDefault(x => x.Id == productId);
            return View("Detail", order);
        }
    }
}
