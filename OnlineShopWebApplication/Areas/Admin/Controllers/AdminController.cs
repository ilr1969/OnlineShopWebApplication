using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using OnlineShopWebApplication.Helpers;
using System.Collections.Generic;
using System.Linq;

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
        private readonly DatabaseContext databaseContext;

        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext databaseContext)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.databaseContext = databaseContext;
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

        public IActionResult Marks()
        {
            var marks = databaseContext.Marks.ToList();
            return View(marks.ToMarkViewModel());
        }

        public IActionResult Models()
        {
            var models = databaseContext.Models.ToList();
            return View(models.ToModelViewModel());
        }

        // GET: AdminController/Users
        public ActionResult Users()
        {
            return View(userManager.Users.ToList());
        }

        // GET: AdminController/Roles
        public ActionResult UserRoles()
        {
            var roleUsers = new List<RoleUsersViewModel>();
            var roles = roleManager.Roles.ToList();
            foreach (var role in roles)
            {
                var dd = userManager.GetUsersInRoleAsync(role.Name).Result.Select(x => x.UserName);
                roleUsers.Add(new RoleUsersViewModel { Id = role.Id, Role = role.Name, UsersInRole = dd.ToList() });
            }
            return View(roleUsers);
        }
    }
}
