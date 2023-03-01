using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;

namespace OnlineShopWebApplication.Views.Shared.Components.Favorite
{
    public class FavoriteViewComponent : ViewComponent
    {
        IFavoriteStorage favoriteStorage;

        public FavoriteViewComponent(IFavoriteStorage favoriteStorage)
        {
            this.favoriteStorage = favoriteStorage;
        }

        public IViewComponentResult Invoke()
        {
            var favoriteList = favoriteStorage.TryGetById(Constants.UserId);
            var favoriteAmount = favoriteList?.FavoriteItems.Count ?? 0;
            return View("favorite", favoriteAmount);
        }
    }
}
