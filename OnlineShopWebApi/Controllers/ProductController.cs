using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        public ProductController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        [HttpGet("GetProductById")]
        public Product GetProductById(Guid productId)
        {
            var product = productStorage.TryGetById(productId);
            return product;
        }
    }
}
