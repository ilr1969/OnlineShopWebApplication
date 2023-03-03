using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        public ICartStorage cartStorage;
        public IMemoryProvider memoryProvider;
        public IOrderStorage orderStorage;
        private readonly DatabaseContext databaseContext;

        public OrderController(ICartStorage cartStorage, IMemoryProvider memoryProvider, IOrderStorage orderStorage, DatabaseContext databaseContext)
        {
            this.cartStorage = cartStorage;
            this.memoryProvider = memoryProvider;
            this.orderStorage = orderStorage;
            this.databaseContext = databaseContext;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int orderNumber)
        {
            var order = orderStorage.TryGetByNumber(orderNumber).ToOrderViewModel();
            return View(order);
        }

        [HttpPost]
        public IActionResult SaveOrder(Guid orderId, OrderStatusViewModel Status)
        {
            orderStorage.ChangeOrderStatus(orderId, (int)Status);
            var order = orderStorage.TryGetById(orderId).ToOrderViewModel();
            return View("Detail", order);
        }
    }
}
