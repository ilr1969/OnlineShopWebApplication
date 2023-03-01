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

        public CompareProduct TryGetById(string userId)
        {
            return databaseContext.CompareProducts.Include(x => x.CompareItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(string userId, Product product)
        {
            var userCompareList = TryGetById(userId);
            if (userCompareList == null)
            {
                userCompareList = new CompareProduct { UserId = userId, CompareItems = new List<CompareItem>() };
                userCompareList.CompareItems.Add(new CompareItem { Product = product, CompareProduct = userCompareList });
                databaseContext.Add(userCompareList);
            }
            else if (!userCompareList.CompareItems.Select(x => x.Product).Contains(product))
            {
                userCompareList.CompareItems.Add(new CompareItem { Product = product, CompareProduct = userCompareList });
            }
            databaseContext.SaveChanges();
        }

        public void Remove(string userId, Guid productId)
        {
            var userFavoriteList = TryGetById(userId);
            var compareItemToRemove = userFavoriteList.CompareItems.First(x => x.Product.Id == productId);
            userFavoriteList.CompareItems.Remove(compareItemToRemove);
            databaseContext.SaveChanges();
        }
    }
}


