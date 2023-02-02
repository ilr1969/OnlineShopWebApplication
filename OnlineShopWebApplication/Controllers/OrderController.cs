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
            var userCart = cartStorage.TryGetByUserId(Constants.UserId);
            order.FullCost = userCart.FullCost;
            order.CartItems = userCart.CartItems;
            order.UserID = Constants.UserId;
            orderStorage.Add(order);
            memoryProvider.WriteOrderToFile();
            cartStorage.ClearBasket();
            return View();
        }
    }
}
