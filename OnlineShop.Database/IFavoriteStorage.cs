using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Database
{
    public interface IFavoriteStorage
    {
        FavoriteProduct TryGetById(string userId, Guid productId);
        List<FavoriteProduct> GetAll(string userId);
        void Add(string userId, Product product);
        void Remove(string userId, Guid productId);
        void TransferFavoriteListOnLogin(string userName, List<FavoriteProduct> unregisteredUserFavoriteList);
    }
}