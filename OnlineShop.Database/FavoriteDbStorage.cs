using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class FavoriteDbStorage : IFavoriteStorage
    {
        private readonly DatabaseContext databaseContext;
        private readonly UserManager<User> userManager;

        public FavoriteDbStorage(DatabaseContext databaseContext, UserManager<User> userManager)
        {
            this.databaseContext = databaseContext;
            this.userManager = userManager;
        }

        public List<FavoriteProduct> GetAll(string userId)
        {
            return databaseContext.FavoriteProducts.Include(x => x.Product).Where(x => x.UserId == userId).ToList();
        }

        public FavoriteProduct TryGetById(string userId, Guid productId)
        {
            return databaseContext.FavoriteProducts.Include(x => x.Product).FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
        }

        public void Add(string userId, Product product)
        {
            var existingProduct = TryGetById(userId, product.Id);
            if (existingProduct == null)
            {
                databaseContext.FavoriteProducts.Add(new FavoriteProduct { UserId = userId, Product = product });
            }
            databaseContext.SaveChanges();
        }

        public void Remove(string userId, Guid productId)
        {
            var userFavoriteProduct = TryGetById(userId, productId);
            databaseContext.FavoriteProducts.Remove(userFavoriteProduct);
            databaseContext.SaveChanges();
        }

        public void TransferFavoriteListOnLogin(string userName, List<FavoriteProduct> unregisteredUserFavoriteList)
        {
            var loggedUserId = userManager.Users.FirstOrDefault(x => x.UserName == userName).Id;
            foreach (var item in unregisteredUserFavoriteList)
            {
                Add(loggedUserId, item.Product);
            }
        }
    }
}


