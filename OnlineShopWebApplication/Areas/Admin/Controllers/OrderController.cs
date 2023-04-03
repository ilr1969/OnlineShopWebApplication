using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Interfaces;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;
using System;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class OrderController : Controller
    {
        public ICartStorage cartStorage;
        public IOrderStorage orderStorage;
        private readonly DatabaseContext databaseContext;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, DatabaseContext databaseContext)
        {
            this.cartStorage = cartStorage;
            this.orderStorage = orderStorage;
            this.databaseContext = databaseContext;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(Guid orderId)
        {
            var order = orderStorage.TryGetById(orderId).ToOrderViewModel();
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
