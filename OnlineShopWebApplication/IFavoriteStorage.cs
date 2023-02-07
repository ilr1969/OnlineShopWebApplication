using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IFavoriteStorage
    {
        static List<ProductClass> favoriteList;
        List<ProductClass> GetAll();
    }
}