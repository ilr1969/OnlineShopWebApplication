using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        readonly IProductStorage productStorage;
        readonly IOrderStorage orderStorage;
        readonly IUserRoleStorage userRoleStorage;
        readonly IUserStorage userStorage;

        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage, IUserRoleStorage userRoleStorage, IUserStorage userStorage)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            this.userRoleStorage = userRoleStorage;
            this.userStorage = userStorage;
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
            return View(userStorage.GetAll());
        }

        // GET: AdminController/Roles
        public ActionResult UserRoles()
        {
            return View(userRoleStorage.GetRolesList());
        }
    }
}
