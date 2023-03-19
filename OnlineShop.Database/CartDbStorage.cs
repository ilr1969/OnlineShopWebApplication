using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Database
{
    public class CartDbStorage : ICartStorage
    {
        private readonly DatabaseContext databaseContext;
        private readonly UserManager<User> userManager;

        public CartDbStorage(DatabaseContext databaseContext, UserManager<User> userManager)
        {
            this.databaseContext = databaseContext;
            this.userManager = userManager;
        }

        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserID == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserID = userId,
                };

                newCart.CartItems = new List<CartItems>
                    {
                        new CartItems
                        {
                            Product = product,
                            Count = 1,
                        }
                    };
                databaseContext.Carts.Add(newCart);
                databaseContext.SaveChanges();
            }
            else
            {
                var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Name == product.Name);
                if (existingCartItem == null)
                {
                    existingCart.CartItems.Add(new CartItems { Product = product, Count = 1 });
                }
                else
                {
                    existingCartItem.Count++;
                }
                databaseContext.SaveChanges();
            }
        }

        public void ClearBasket(string userId)
        {
            var userCart = TryGetByUserId(userId);
            databaseContext.Carts.Remove(userCart);
            databaseContext.SaveChanges();
        }

        public void ChangeCount(string userId, int count, string product)
        {
            var userCart = TryGetByUserId(userId);
            var prodToChange = userCart.CartItems.First(x => x.Product.Name == product);
            prodToChange.Count += count;
            if (prodToChange.Count == 0)
            {
                userCart.CartItems.Remove(prodToChange);
            }
            if (userCart.CartItems.Count == 0)
            {
                userCart = null;
            }
            databaseContext.SaveChanges();
        }

        public Cart TryGetCartById(Guid cartId)
        {
            return databaseContext.Carts.FirstOrDefault(x => x.Id == cartId);
        }

        public void TransferProductsOnLogin(string userName, List<CartItems> unregisteredUserCdrtItems)
        {
            var loggedUserId = userManager.Users.FirstOrDefault(x => x.UserName == userName).Id;
            foreach (var item in unregisteredUserCdrtItems)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    Add(item.Product, loggedUserId);
                }

            }
        }
    }
}
