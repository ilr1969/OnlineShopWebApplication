using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Database.Storages
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
            return databaseContext.Products.Include(x => x.ProductImages).FirstOrDefault(product => product.Id == productId);
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.Include(x => x.ProductImages).Include(x => x.Mark).Include(x => x.Model).Where(x => x.IsDeleted == false).ToList();
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Remove(Guid productId)
        {
            databaseContext.Products.First(x => x.Id == productId).IsDeleted = true;
            databaseContext.SaveChanges();
        }
    }
}
