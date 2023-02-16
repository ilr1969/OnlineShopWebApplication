using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class AdminController : Controller
    {
        IProductStorage productStorage;
        IOrderStorage orderStorage;

        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
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
