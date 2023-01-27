using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class CartInMemoryStorage : ICartStorage
    {
        public static List<CartClass> cart = new List<CartClass>();

        public CartClass TryGetByUserId(string userId)
        {
            return cart.FirstOrDefault(x => x.UserID == userId);
        }

        public void Add(ProductClass product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                cart.Add(new CartClass
                {
                    Id = Guid.NewGuid(),
                    UserID = userId,
                    CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Product = product,
                            Count = 1
                        }
                    }
                });
            }
            else
            {
                var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Name == product.Name);
                if (existingCartItem == null)
                {
                    existingCart.CartItems.Add(new CartItem { Id = Guid.NewGuid(), Product = product, Count = 1 });
                }
                else
                {
                    existingCartItem.Count++;
                }
            }
        }

        public void ClearBasket()
        {
            cart.Clear();
        }

        public void ChangeCount(int count, string product)
        {
            var userCart = cart.First(x => x.UserID == Constants.UserId);
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
        }
    }
}
