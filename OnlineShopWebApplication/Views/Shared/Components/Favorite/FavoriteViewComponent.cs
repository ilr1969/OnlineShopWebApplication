using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShop.Database.Storages;
using OnlineShopWebApplication.Helpers;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Views.Shared.Components.Favorite
{
    public class FavoriteViewComponent : ViewComponent
    {
        private readonly IFavoriteStorage favoriteStorage;
        private readonly UserManager<User> userManager;

        public FavoriteViewComponent(IFavoriteStorage favoriteStorage, UserManager<User> userManager)
        {
            this.favoriteStorage = favoriteStorage;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            List<FavoriteProduct> favoriteList;
            if (HttpContext.User.Identity.Name == null && Request.Cookies.ContainsKey("TempUser"))
            {
                var tempUserId = Request.Cookies["TempUser"].ToString();
                favoriteList = favoriteStorage.GetAll(tempUserId);
            }
            else
            {
                favoriteList = favoriteStorage.GetAll(userManager.GetUserId(HttpContext.User));
            }
            var favoriteAmount = favoriteList?.Count ?? 0;
            return View("favorite", favoriteAmount);
        }
    }
}
