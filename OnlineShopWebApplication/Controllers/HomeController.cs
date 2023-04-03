using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;
using System.IO;
using System.Linq;

namespace OnlineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IProductStorage productStorage, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
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
            return View();
        }

        public FileContentResult DisplayAvatar()
        {
            var currentUser = userManager.Users.Include(x => x.UserImages).FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            string fileName = currentUser?.UserImages.Count != 0 ? currentUser.UserImages[0].Name : "/images/users/emptyAvatar.png";
            var path = Path.Combine(webHostEnvironment.WebRootPath + fileName);
            byte[] content = System.IO.File.ReadAllBytes(path);
            return File(content, "image/png");
        }
    }
}