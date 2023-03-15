using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductStorage productStorage;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IProductStorage productStorage, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.productStorage = productStorage;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var products = productStorage.GetAll();
            return View(products.ToProductsViewModel());
        }

        public IActionResult Cart()
        {
            return View("Cart");
        }

        public IActionResult Privacy()
        {
            var iser = userManager.GetUserAsync(HttpContext.User).Result;
            return View();
        }

        public FileContentResult DisplayAvatar()
        {
            var currentUser = userManager.Users.Where(x => x.UserName == userManager.GetUserAsync(HttpContext.User).Result.UserName).Include(x => x.Photos).FirstOrDefault();
            string fileName = currentUser.Photos.Count != 0 ? currentUser.Photos[0].Name : "/images/users/emptyAvatar.png";
            var path = Path.Combine(webHostEnvironment.WebRootPath + fileName);
            byte[] content = System.IO.File.ReadAllBytes(path);
            return File(content, "image/png");
        }
    }
}