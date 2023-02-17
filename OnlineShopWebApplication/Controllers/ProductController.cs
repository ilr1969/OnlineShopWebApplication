using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        public ProductController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        // GET: ProductController
        public IActionResult Index(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }

        // GET: ProductController/EditProduct
        public ActionResult EditProduct(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveProduct(Guid productId, ProductClass product)
        {
            var productToEdit = productStorage.TryGetById(productId);
            if (ModelState.IsValid)
            {
                productToEdit.Name = product.Name;
                productToEdit.Description = product.Description;
                productToEdit.Cost = product.Cost;
                productToEdit.ImagePath = product.ImagePath;
                return Redirect("/admin/products");
            }
            return RedirectToAction("edit", productToEdit);
        }
        public IActionResult Remove(Guid productId)
        {
            var productList = productStorage.GetAll();
            var productToRemove = productStorage.TryGetById(productId);
            productList.Remove(productToRemove);
            return Redirect("/admin/products");
        }

        // GET: ProductController/AddProduct
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductClass product)
        {
            if (ModelState.IsValid)
            {
                var productList = productStorage.GetAll();
                productList.Add(product);
                return Redirect("/admin/products");
            }
            return View();
        }
    }
}
