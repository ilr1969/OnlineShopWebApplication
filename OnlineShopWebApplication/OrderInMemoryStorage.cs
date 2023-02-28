using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class OrderInMemoryStorage : IOrderStorage
    {
        public List<OrderViewModel> orders = new List<OrderViewModel>();

        public void Add(OrderViewModel order)
        {
            orders.Add(order);
        }

        public void ChangeOrderStatus(Guid productId, OrderStatusViewModel status)
        {
            var order = orders.First(x => x.Id == productId);
            order.Status = status;
        }

        public List<OrderViewModel> GetOrderList()
        {
            return orders;
        }
    }
}
