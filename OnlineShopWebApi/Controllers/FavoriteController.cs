using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FavoriteController : Controller
    {
        readonly IFavoriteStorage favoriteStorage;
        readonly UserManager<User> userManager;

        public FavoriteController(IFavoriteStorage favoriteStorage, UserManager<User> userManager)
        {
            this.favoriteStorage = favoriteStorage;
            this.userManager = userManager;
        }
        // GET: FavoriteController
        [HttpGet("GetFavoriteList")]
        public List<Product> GetFavoriteList(string userName)
        {
            var user = userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return new List<Product>();
            }
            var favoriteList = favoriteStorage.GetAll(user.Id);
            var favorite = favoriteList.Select(x => x.Product).ToList();
            return favorite;
        }
    }
}
