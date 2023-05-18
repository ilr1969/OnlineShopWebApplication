using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Interfaces
{
    public interface ICartStorage
    {
        static readonly List<Cart> carts;

        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);

        void ClearBasket(string userId);

        void ChangeCount(string userId, int count, string product);

        Cart TryGetCartById(Guid cartId);

        void TransferProductsOnLogin(string userName, List<CartItems> unregisteredUserCdrtItems, string tempUserId);
    }
}
