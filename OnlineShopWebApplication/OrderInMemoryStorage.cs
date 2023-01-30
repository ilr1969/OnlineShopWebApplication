using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class OrderInMemoryStorage : IOrderStorage
    {
        public List<CartClass> orderStorage = new List<CartClass>();
    }
}
