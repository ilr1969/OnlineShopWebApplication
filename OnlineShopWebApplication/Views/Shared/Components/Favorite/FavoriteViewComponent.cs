using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;

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
            var favoriteList = favoriteStorage.GetAll(userManager.GetUserId(HttpContext.User));
            var favoriteAmount = favoriteList?.Count ?? 0;
            return View("favorite", favoriteAmount);
        }
    }
}
