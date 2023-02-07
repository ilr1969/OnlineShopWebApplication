using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class FavoriteInMemoryStorage : IFavoriteStorage
    {
        public List<ProductClass> favoriteList = new List<ProductClass>();
        public List<ProductClass> GetAll()
        {
            return favoriteList;
        }
    }
}