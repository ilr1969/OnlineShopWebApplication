using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class FavoriteDbStorage : IFavoriteStorage
    {
        private readonly DatabaseContext databaseContext;
        private readonly IProductStorage productStorage;

        public FavoriteDbStorage(DatabaseContext databaseContext, IProductStorage productStorage)
        {
            this.databaseContext = databaseContext;
            this.productStorage = productStorage;
        }

        public FavoriteProduct TryGetById(string userId)
        {
            return databaseContext.FavoriteProducts.Include(x => x.FavoriteItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(string userId, Product product)
        {
            var userFavoriteList = TryGetById(userId);
            if (userFavoriteList == null)
            {
                userFavoriteList = new FavoriteProduct { UserId = userId, FavoriteItems = new List<FavoriteItem>() };
                var userFavoriteItem = new FavoriteItem
                {
                    Product = product,
                    FavoriteProduct = userFavoriteList
                };
                userFavoriteList.FavoriteItems.Add(userFavoriteItem);
                databaseContext.Add(userFavoriteList);
            }
            else if (!userFavoriteList.FavoriteItems.Select(x => x.Product).Contains(product))
            {
                userFavoriteList.FavoriteItems.Add(new FavoriteItem { Product = product, FavoriteProduct = userFavoriteList});
            }
            databaseContext.SaveChanges();
        }

        public void Remove(string userId, Guid productId)
        {
            var userFavoriteList = TryGetById(userId);
            var favoriteItemToRemove = userFavoriteList.FavoriteItems.First(x => x.Product.Id == productId);
            userFavoriteList.FavoriteItems.Remove(favoriteItemToRemove);
            databaseContext.SaveChanges();
        }
    }
}


