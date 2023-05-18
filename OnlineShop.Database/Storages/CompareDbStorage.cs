using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Database.Storages
{
    public class CompareDbStorage : ICompareStorage
    {
        private readonly DatabaseContext databaseContext;
        private readonly UserManager<User> userManager;

        public CompareDbStorage(DatabaseContext databaseContext, UserManager<User> userManager)
        {
            this.databaseContext = databaseContext;
            this.userManager = userManager;
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

        public void TransferCompareListOnLogin(string userName, List<Product> unregisteredUserCompareList, string tempUserId)
        {
            var loggedUserId = userManager.Users.FirstOrDefault(x => x.UserName == userName).Id;
            foreach (var item in unregisteredUserCompareList)
            {
                Add(loggedUserId, item);
            }
            var tempUserCompareList = databaseContext.CompareProducts.FirstOrDefault(x => x.UserId == tempUserId);
            databaseContext.CompareProducts.Remove(tempUserCompareList);
            databaseContext.SaveChanges();
        }
    }
}