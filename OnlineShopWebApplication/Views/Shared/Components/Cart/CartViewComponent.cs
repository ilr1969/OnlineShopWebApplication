﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;

namespace OnlineShopWebApplication.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        private readonly UserManager<User> userManager;

        public CartViewComponent(ICartStorage cartStorage, UserManager<User> userManager)
        {
            this.cartStorage = cartStorage;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetByUserId(userManager.GetUserId(HttpContext.User));
            var cartToView = cart.ToCartViewModel();
            var productcount = cartToView?.Amount ?? 0;
            return View("cart", productcount);
        }
    }
}
