using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IOrderStorage
    {
        public static List<OrderClass> orderStorage = new List<OrderClass>();
    }
}
