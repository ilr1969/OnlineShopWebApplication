using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly DatabaseContext databaseContext;
        public ProductController(IProductStorage productStorage, DatabaseContext databaseContext)
        {
            this.productStorage = productStorage;
            this.databaseContext = databaseContext;
        }

        // GET: ProductController/EditProduct
        public ActionResult EditProduct(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product.ToProductViewModel());
        }

        [HttpPost]
        public IActionResult SaveProduct(Guid productId, ProductViewModel product)
        {
            var productToEdit = productStorage.TryGetById(productId);
            if (ModelState.IsValid)
            {
                productToEdit.Name = product.Name;
                productToEdit.Description = product.Description;
                productToEdit.Cost = product.Cost;
                productToEdit.ImagePath = product.ImagePath;
                databaseContext.SaveChanges();
                return Redirect("/admin/admin/products");
            }
            return RedirectToAction("EditProduct", productToEdit.ToProductViewModel());
        }
        public IActionResult Remove(Guid productId)
        {
            productStorage.Remove(productId);
            return Redirect("/admin/admin/products");
        }

        // GET: ProductController/AddProduct
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                productStorage.Add(productViewModel.ToProduct());
                return Redirect("/admin/admin/products");
            }
            return View();
        }
    }
}
