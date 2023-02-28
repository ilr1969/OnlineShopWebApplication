using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductStorage productStorage;
        private readonly ToViewModelConverter toViewModelConverter;

        public HomeController(ILogger<HomeController> logger, IProductStorage productStorage, ToViewModelConverter toViewModelConverter)
        {
            _logger = logger;
            this.productStorage = productStorage;
            this.toViewModelConverter = toViewModelConverter;
        }

        public IActionResult Index()
        {
            var products = productStorage.GetAll();
            return View(toViewModelConverter.ProductsToViewModel(products));
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
