using System;
using System.Collections.Generic;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public interface IFavoriteStorage
    {
        FavoriteProduct TryGetById(string userId, Guid productId);
        List<FavoriteProduct> GetAll(string userId);
        void Add(string userId, Product product);
        void Remove(string userId, Guid productId);
    }
}