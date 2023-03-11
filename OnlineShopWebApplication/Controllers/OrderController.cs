using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    [Authorize]
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

        [HttpPost]
        // GET: OrderController/Success
        public ActionResult Success(OrderDeliveryInfoViewModel orderDeliveryInfoViewModel)
        {
            var order = new Order
            {
                DeliveryInfo = orderDeliveryInfoViewModel.ToOrderDeliveryInfo(),
                CartItems = cartStorage.TryGetByUserId(Constants.UserId).CartItems
            };

            orderStorage.Add(order);
            cartStorage.ClearBasket(Constants.UserId);
            return View();
        }
    }
}
