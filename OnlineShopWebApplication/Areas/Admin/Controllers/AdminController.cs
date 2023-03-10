using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        readonly IProductStorage productStorage;
        readonly IOrderStorage orderStorage;

        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: AdminController
        public ActionResult Orders()
        {
            return View(orderStorage.GetOrderList().ToOrdersViewModel());
        }

        // GET: AdminController/Products/
        public ActionResult Products()
        {
            return View(productStorage.GetAll().ToProductsViewModel());
        }

        // GET: AdminController/Users
        public ActionResult Users()
        {
            return View(userManager.Users.ToList());
        }

        // GET: AdminController/Roles
        public ActionResult UserRoles()
        {
            return View(roleManager.Roles.ToList());
        }
    }
}
