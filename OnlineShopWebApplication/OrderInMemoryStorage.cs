using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class OrderInMemoryStorage : IOrderStorage
    {
        public List<OrderClass> orders = new List<OrderClass>();

        public void Add(OrderClass order)
        {
            orders.Add(order);
        }

        public List<OrderClass> GetOrderList()
        {
            return orders;
        }
    }
}
