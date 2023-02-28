using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly ToViewModelConverter toViewModelConverter;
        private readonly DatabaseContext databaseContext;
        public ProductController(IProductStorage productStorage, ToViewModelConverter toViewModelConverter, DatabaseContext databaseContext)
        {
            this.productStorage = productStorage;
            this.toViewModelConverter = toViewModelConverter;
            this.databaseContext = databaseContext;
        }

        // GET: ProductController/EditProduct
        public ActionResult EditProduct(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(toViewModelConverter.ProductToViewModel(product));
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
            return RedirectToAction("EditProduct", toViewModelConverter.ProductToViewModel(productToEdit));
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
        public IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                productStorage.Add(ToModelConverter.ProductToModel(product));
                return Redirect("/admin/admin/products");
            }
            return View();
        }
    }
}
