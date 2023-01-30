using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface ICartStorage
    {
        static List<CartClass> carts = new List<CartClass>();

        CartClass TryGetByUserId(string userId);

        void Add(ProductClass product, string userId);

        void ClearBasket();

        void ChangeCount(int count, string product);
    }
}
