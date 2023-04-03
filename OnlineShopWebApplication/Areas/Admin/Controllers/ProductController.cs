using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using OnlineShopWebApplication.Helpers;
using System;
using System.Linq;

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
            if (productToEdit == null)
            {
                ModelState.AddModelError("Error", "Запись была удалена!");
                return View("EditProduct", editProductViewModel);
            }
            if (ModelState.IsValid)
            {
                productToEdit.Name = editProductViewModel.Name;
                productToEdit.Description = editProductViewModel.Description;
                productToEdit.Cost = editProductViewModel.Cost;
                databaseContext.Entry(productToEdit).Property("ConcurrencyToken").OriginalValue = editProductViewModel.ConcurrencyToken;

                if (editProductViewModel.FileToUpload != null)
                {
                    var fileName = fileUploader.UploadProductImage(editProductViewModel.ID.ToString(), editProductViewModel.FileToUpload);
                    productToEdit.ProductImages.Add(new ProductImages { Name = fileName });
                }

                try
                {
                    databaseContext.SaveChanges();
                    return Redirect("/admin/admin/products");
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("Error", "Запись была изменена другим пользователем!");
                    return View("EditProduct", editProductViewModel);
                }
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
            var marks = new SelectList(databaseContext.Marks.Select(x => x.Name).ToList());
            var models = new SelectList(databaseContext.Models.Select(x => x.Name).ToList());
            ViewBag.marks = marks;
            ViewBag.models = models;
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
                    Name = addProductViewModel.Mark + " " + addProductViewModel.Model,
                    Mark = databaseContext.Marks.First(x => x.Name == addProductViewModel.Mark),
                    Model = databaseContext.Models.First(x => x.Name == addProductViewModel.Model),
                    Description = addProductViewModel.Description,
                    Cost = addProductViewModel.Cost
                };
                if (addProductViewModel.FileToUpload != null)
                {
                    var fileName = fileUploader.UploadProductImage(addProductViewModel.ID.ToString(), addProductViewModel.FileToUpload);
                    product.ProductImages.Add(new ProductImages { Name = fileName });
                }
                productStorage.Add(product);
                return Redirect("/admin/admin/products");
            }
            return View();
        }

        public IActionResult DeletePhoto(Guid productId, Guid imageId)
        {
            var product = databaseContext.Products.Where(x => x.Id == productId).Include(x => x.ProductImages).First();
            var photoToDelete = product.ProductImages.Where(y => y.Id == imageId).First();
            product.ProductImages.Remove(photoToDelete);
            databaseContext.SaveChanges();
            return Redirect("/admin/admin/products");
        }
    }
}
