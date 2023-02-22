using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OnlineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductStorage productStorage;

        public HomeController(ILogger<HomeController> logger, IProductStorage productStorage)
        {
            _logger = logger;
            this.productStorage = productStorage;
        }

        public IActionResult Index()
        {
            var products = productStorage.GetAll();
            return View(products);
        }

        public IActionResult Cart()
        {
            return View("Cart");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
