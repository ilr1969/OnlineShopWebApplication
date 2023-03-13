using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Areas.Admin.Models;
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
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IProductStorage productStorage, DatabaseContext databaseContext, IWebHostEnvironment webHostEnvironment)
        {
            this.productStorage = productStorage;
            this.databaseContext = databaseContext;
            this.webHostEnvironment = webHostEnvironment;
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
                    var filePath = Path.Combine(webHostEnvironment.WebRootPath + "/images/" + editProductViewModel.ID + "/");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    var fileName = Guid.NewGuid() + "." + editProductViewModel.FileToUpload.FileName.Split(".").Last();
                    using (var fileStream = new FileStream(filePath + fileName, FileMode.Create))
                    {
                        editProductViewModel.FileToUpload.CopyTo(fileStream);
                    }
                    productToEdit.ImagePath = "/images/" + editProductViewModel.ID + "/" + fileName;
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
                if (addProductViewModel.FileToUpload != null)
                {
                    var filePath = Path.Combine(webHostEnvironment.WebRootPath + "/images/" + addProductViewModel.ID + "/");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    var fileName = Guid.NewGuid() + "." + addProductViewModel.FileToUpload.FileName.Split(".").Last();
                    using (var fileStream = new FileStream(filePath + fileName, FileMode.Create))
                    {
                        addProductViewModel.FileToUpload.CopyTo(fileStream);
                    }
                    var product = new ProductViewModel()
                    {
                        ID = addProductViewModel.ID,
                        Name = addProductViewModel.Name,
                        Description = addProductViewModel.Description,
                        Cost = addProductViewModel.Cost,
                        ImagePath = "/images/" + addProductViewModel.ID + "/" + fileName
                    };
                    productStorage.Add(product.ToProduct());
                }
                return Redirect("/admin/admin/products");
            }
            return View();
        }
    }
}
