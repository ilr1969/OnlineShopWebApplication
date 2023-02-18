using System;
using System.Collections.Generic;
using System.Linq;
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

        public void ChangeOrderStatus(Guid productId, OrderStatus status)
        {
            var order = orders.First(x => x.Id == productId);
            order.Status = status;
        }

        public List<OrderClass> GetOrderList()
        {
            return orders;
        }
    }
}
