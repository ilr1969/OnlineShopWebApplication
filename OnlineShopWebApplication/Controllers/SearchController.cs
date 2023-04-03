using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using System.Linq;

namespace OnlineShopWebApplication.Controllers
{
    public class SearchController : Controller
    {
        IProductStorage productStorage;

        public SearchController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        // GET: SearchController
        [HttpPost]
        public ActionResult Index(string searchText)
        {
            var products = productStorage.GetAll();
            if (searchText != null)
            {
                var SearchedProducts = products.Where(x => x.Name.ToLower().Contains(searchText.ToLower())).ToList();
                return View(SearchedProducts);
            }
            else
            {
                return Redirect("/home/index");
            }
        }
    }
}
