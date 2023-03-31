using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SearchController : Controller
    {
        readonly IProductStorage productStorage;

        public SearchController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        [HttpGet("SearchProduct")]
        public List<Product> Index(string searchText)
        {
            var products = productStorage.GetAll();
            var SearchedProducts = products.Where(x => x.Name.ToLower().Contains(searchText.ToLower())).ToList();
            return SearchedProducts;
        }
    }
}
