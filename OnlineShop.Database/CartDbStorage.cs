using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class CartDbStorage : ICartStorage
    {
        private readonly DatabaseContext databaseContext;

        public CartDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
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

                newCart.CartItems = new List<CartItem>
                    {
                        new CartItem
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
                    existingCart.CartItems.Add(new CartItem { Product = product, Count = 1 });
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
    }
}
