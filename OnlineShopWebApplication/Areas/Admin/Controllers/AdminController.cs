using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        IProductStorage productStorage;
        IOrderStorage orderStorage;
        IUserRoleStorage userRoleStorage;
        IUserStorage userStorage;
        private readonly ToViewModelConverter toViewModelConverter;

        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage, IUserRoleStorage userRoleStorage, IUserStorage userStorage, ToViewModelConverter toViewModelConverter)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            this.userRoleStorage = userRoleStorage;
            this.userStorage = userStorage;
            this.toViewModelConverter = toViewModelConverter;
        }

        // GET: AdminController
        public ActionResult Orders()
        {
            return View(orderStorage.GetOrderList());
        }

        // GET: AdminController/Products/
        public ActionResult Products()
        {
            return View(toViewModelConverter.ProductsToViewModel(productStorage.GetAll()));
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
