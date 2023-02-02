using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        ICartStorage cartStorage;

        public CartViewComponent(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetByUserId(Constants.UserId);
            var productcount = cart?.Amount ?? 0;
            return View("cart", productcount);
        }
    }
}
