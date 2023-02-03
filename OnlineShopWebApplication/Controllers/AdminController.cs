using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Orders()
        {
            return View();
        }

        // GET: AdminController/Products/
        public ActionResult Products()
        {
            return View();
        }

        // GET: AdminController/Users
        public ActionResult Users()
        {
            return View();
        }

        // GET: AdminController/Roles
        public ActionResult Roles()
        {
            return View();
        }
    }
}
