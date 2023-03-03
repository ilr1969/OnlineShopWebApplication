using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;

        public CartViewComponent(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetByUserId(Constants.UserId);
            var cartToView = cart.ToCartViewModel();
            var productcount = cartToView?.Amount ?? 0;
            return View("cart", productcount);
        }
    }
}
