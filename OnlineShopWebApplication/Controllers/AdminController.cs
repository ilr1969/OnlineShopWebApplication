using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class AdminController : Controller
    {
        IProductStorage productStorage;
        IOrderStorage orderStorage;
        IUserRoleStorage userRoleStorage;

        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage, IUserRoleStorage userRoleStorage)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            this.userRoleStorage = userRoleStorage;
        }

        // GET: AdminController
        public ActionResult Orders()
        {
            return View(orderStorage.GetOrderList());
        }

        // GET: AdminController/Products/
        public ActionResult Products()
        {
            return View(productStorage.GetAll());
        }

        // GET: AdminController/Users
        public ActionResult Users()
        {
            return View();
        }

        // GET: AdminController/Roles
        public ActionResult UserRoles()
        {
            return View(userRoleStorage.GetRolesList());
        }
    }
}
