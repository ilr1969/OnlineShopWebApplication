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
        public IActionResult Index(int productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int productId, string name, int cost, string description, string imagepath)
        {
            var productToEdit = productStorage.TryGetById(productId);
            productToEdit.Name = name;
            productToEdit.Description = description;
            productToEdit.Cost = cost;
            productToEdit.ImagePath = imagepath;
            return Redirect("/admin/products");
        }
        public IActionResult Remove(int productId)
        {
            var productList = productStorage.GetAll();
            var productToRemove = productStorage.TryGetById(productId);
            productList.Remove(productToRemove);
            return Redirect("/admin/products");
        }
        [HttpPost]
        public IActionResult Add(string name, int cost, string description, string imagepath)
        {
            var productList = productStorage.GetAll();
            productList.Add(new ProductClass(name, cost, description, imagepath));
            return Redirect("/admin/products");
        }
    }
}
