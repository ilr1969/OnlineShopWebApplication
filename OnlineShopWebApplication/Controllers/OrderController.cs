using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class OrderController : Controller
    {
        public ICartStorage cartStorage;
        public IMemoryProvider memoryProvider;

        public OrderController(ICartStorage cartStorage, IMemoryProvider memoryProvider)
        {
            this.cartStorage = cartStorage;
            this.memoryProvider = memoryProvider;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Success
        public ActionResult Success()
        {
            memoryProvider.WriteOrderToFile();
            cartStorage.ClearBasket();
            return View();
        }
    }
}
