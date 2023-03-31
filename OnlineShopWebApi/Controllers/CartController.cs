using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CartController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly ICartStorage cartStorage;
        private readonly UserManager<User> userManager;
        public CartController(IProductStorage productStorage, ICartStorage cartStorage, UserManager<User> userManager)
        {
            this.productStorage = productStorage;
            this.cartStorage = cartStorage;
            this.userManager = userManager;
        }
        [HttpGet("GetCart")]
        public Cart Index()
        {
            return cartStorage.TryGetByUserId(userManager.GetUserId(HttpContext.User));
        }

        [HttpPost("AddProductToCart")]
        public ActionResult Add(Guid productId, string userId)
        {
            var product = productStorage.TryGetById(productId);
            cartStorage.Add(product, userId);
            return Ok();
        }


        [HttpPost("ClearCart")]
        public ActionResult Clear(string userId)
        {
            cartStorage.ClearBasket(userId);
            return Ok();
        }
    }
}
