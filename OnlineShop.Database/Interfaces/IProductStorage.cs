using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Interfaces
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
