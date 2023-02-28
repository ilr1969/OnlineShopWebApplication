using System;
using System.Collections.Generic;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public interface IProductStorage
    {
        static List<Product> productsList;
        Product TryGetById(Guid productId);
        List<Product> GetAll();
        void Add(Product product);
        void Remove(Guid productId);
    }
}
