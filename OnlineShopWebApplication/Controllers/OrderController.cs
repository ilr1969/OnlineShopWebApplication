using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class OrderController : Controller
    {
        public ICartStorage cartStorage;
        public IMemoryProvider memoryProvider;
        public IOrderStorage orderStorage;

        public OrderController(ICartStorage cartStorage, IMemoryProvider memoryProvider, IOrderStorage orderStorage)
        {
            this.cartStorage = cartStorage;
            this.memoryProvider = memoryProvider;
            this.orderStorage = orderStorage;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // GET: OrderController/Success
        public ActionResult Success(OrderClass order)
        {
            order.userCart = cartStorage.TryGetByUserId(Constants.UserId);
            orderStorage.Add(order);
            memoryProvider.WriteOrderToFile();
            cartStorage.ClearBasket();
            return View();
        }

        public IActionResult Detail(Guid productId)
        {
            var order = orderStorage.GetOrderList().FirstOrDefault(x => x.Id == productId);
            return View(order);
        }

        [HttpPost]
        public IActionResult SaveOrder(Guid productId, OrderStatus status)
        {
            orderStorage.ChangeOrderStatus(productId, status);
            var order = orderStorage.GetOrderList().FirstOrDefault(x => x.Id == productId);
            return View("Detail", order);
        }
    }
}
