using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly DatabaseContext databaseContext;
        private readonly FileUploader fileUploader;
        public ProductController(IProductStorage productStorage, DatabaseContext databaseContext, FileUploader fileUploader)
        {
            this.productStorage = productStorage;
            this.databaseContext = databaseContext;
            this.fileUploader = fileUploader;
        }

        // GET: ProductController/EditProduct
        public ActionResult EditProduct(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public IActionResult SaveProduct(EditProductViewModel editProductViewModel)
        {
            var productToEdit = productStorage.TryGetById(editProductViewModel.ID);
            if (ModelState.IsValid)
            {
                productToEdit.Name = editProductViewModel.Name;
                productToEdit.Description = editProductViewModel.Description;
                productToEdit.Cost = editProductViewModel.Cost;

                if (editProductViewModel.FileToUpload != null)
                {
                    var fileName = fileUploader.UploadProductImage(editProductViewModel.ID.ToString(), editProductViewModel.FileToUpload);
                    productToEdit.Images.Add(new Image { Name = fileName });
                }

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
        public IActionResult Add(AddProductViewModel addProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Id = addProductViewModel.ID,
                    Name = addProductViewModel.Name,
                    Description = addProductViewModel.Description,
                    Cost = addProductViewModel.Cost
                };
                if (addProductViewModel.FileToUpload != null)
                {
                    var fileName = fileUploader.UploadProductImage(addProductViewModel.ID.ToString(), addProductViewModel.FileToUpload);
                    product.Images.Add(new Image { Name = fileName });
                }
                productStorage.Add(product);
                return Redirect("/admin/admin/products");
            }
            return View();
        }
    }
}
