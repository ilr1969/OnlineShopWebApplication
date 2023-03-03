using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class CompareDbStorage : ICompareStorage
    {
        private readonly DatabaseContext databaseContext;
        private readonly IProductStorage productStorage;

        public CompareDbStorage(DatabaseContext databaseContext, IProductStorage productStorage)
        {
            this.databaseContext = databaseContext;
            this.productStorage = productStorage;
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.CompareProducts.Include(x => x.Product).Where(x => x.UserId == userId).Select(x => x.Product).ToList();
        }

        public CompareProduct TryGetById(string userId, Guid productId)
        {
            return databaseContext.CompareProducts.Include(x => x.Product).FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
        }

        public void Add(string userId, Product product)
        {
            var userCompareProduct = TryGetById(userId, product.Id);
            if (userCompareProduct == null)
            {
                databaseContext.CompareProducts.Add(new CompareProduct { UserId = userId, Product = product });
            }
            databaseContext.SaveChanges();
        }

        public void Remove(string userId, Guid productId)
        {
            var compareItemToRemove = TryGetById(userId, productId);
            databaseContext.CompareProducts.Remove(compareItemToRemove);
            databaseContext.SaveChanges();
        }
    }
}


