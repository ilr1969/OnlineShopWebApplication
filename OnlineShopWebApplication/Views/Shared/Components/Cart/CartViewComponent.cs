using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        private readonly ToViewModelConverter toViewModelConverter;

        public CartViewComponent(ICartStorage cartStorage, ToViewModelConverter toViewModelConverter)
        {
            this.cartStorage = cartStorage;
            this.toViewModelConverter = toViewModelConverter;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetByUserId(Constants.UserId);
            var cartToView = toViewModelConverter.CartToViewModel(cart);
            var productcount = cartToView?.Amount ?? 0;
            return View("cart", productcount);
        }
    }
}
