using System;
using System.Collections.Generic;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public interface ICompareStorage
    {
        CompareProduct TryGetById(string userId);
        void Add(string userId, Product product);
        void Remove(string userId, Guid productId);
    }
}