using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductStorage iProductStorage;

        public HomeController(ILogger<HomeController> logger, IProductStorage productStorage)
        {
            _logger = logger;
            iProductStorage = productStorage;
        }

        public IActionResult Index(int id)
        {
            var products = iProductStorage.GetAll();
            return View(products);
        }

        public IActionResult Cart(int id)
        {
            return View("Cart");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
