using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IFavoriteStorage
    {
        static List<ProductViewModel> favoriteList;
        List<ProductViewModel> GetAll();
    }
}