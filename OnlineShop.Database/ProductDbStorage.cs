using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class ProductDbStorage : IProductStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Product TryGetById(Guid productId)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == productId);
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Remove(Guid productId)
        {
            databaseContext.Products.Remove(TryGetById(productId));
            databaseContext.SaveChanges();
        }
    }
}
