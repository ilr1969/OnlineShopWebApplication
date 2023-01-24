using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public static class CartStorage
    {
        public static List<CartClass> carts = new List<CartClass>();

        internal static CartClass TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserID == userId);
        }

        internal static void Add(ProductClass product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                carts.Add(new CartClass
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
    }
}
