using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CompareController : Controller
    {
        public IProductStorage productStorage;
        private readonly ICompareStorage compareStorage;
        private readonly UserManager<User> userManager;

        public CompareController(IProductStorage productStorage, ICompareStorage compareStorage, UserManager<User> userManager)
        {
            this.productStorage = productStorage;
            this.compareStorage = compareStorage;
            this.userManager = userManager;
        }

        [HttpGet("GetCompareList")]
        public List<Product> GetCompareList(string userName)
        {
            var user = userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return new List<Product>();
            }
            var compareList = compareStorage.GetAll(user.Id);
            return compareList;
        }
    }
}
