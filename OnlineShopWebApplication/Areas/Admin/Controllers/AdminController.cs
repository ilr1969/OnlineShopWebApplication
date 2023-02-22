﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        IProductStorage productStorage;
        IOrderStorage orderStorage;
        IUserRoleStorage userRoleStorage;
        IUserStorage userStorage;

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
            return View(userStorage.GetAll());
        }

        // GET: AdminController/Roles
        public ActionResult UserRoles()
        {
            return View(userRoleStorage.GetRolesList());
        }
    }
}