using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class FavoriteInMemoryStorage : IFavoriteStorage
    {
        public List<ProductViewModel> favoriteList = new List<ProductViewModel>();
        public List<ProductViewModel> GetAll()
        {
            return favoriteList;
        }
    }
}