using System;
using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IOrderStorage
    {
        static List<OrderClass> orders;

        void Add(OrderClass order);
        List<OrderClass> GetOrderList();
        void ChangeOrderStatus(Guid productId, OrderStatus status);
    }
}