using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Database
{
    public interface ICompareStorage
    {
        CompareProduct TryGetById(string userId, Guid productId);
        List<Product> GetAll(string userId);
        void Add(string userId, Product product);
        void Remove(string userId, Guid productId);
        void TransferCompareListOnLogin(string userName, List<Product> unregisteredUserCompareList);
    }
}