using System.Collections.Generic;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public interface ICartStorage
    {
        static List<Cart> carts;

        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);

        void ClearBasket(string userId);

        void ChangeCount(string userId, int count, string product);
    }
}
