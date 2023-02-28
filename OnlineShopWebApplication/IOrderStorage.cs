using System;
using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IOrderStorage
    {
        static List<OrderViewModel> orders;

        void Add(OrderViewModel order);
        List<OrderViewModel> GetOrderList();
        void ChangeOrderStatus(Guid productId, OrderStatusViewModel status);
    }
}