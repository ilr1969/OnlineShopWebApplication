using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class AdminController : Controller
    {
        IProductStorage productStorage;

        public AdminController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        // GET: AdminController
        public ActionResult Orders()
        {
            return View();
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
        public ActionResult Roles()
        {
            return View();
        }
        // GET: AdminController/AddProduct
        public ActionResult AddProduct()
        {
            return View();
        }
        // GET: AdminController/EditProduct
        public ActionResult EditProduct(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }
    }
}
