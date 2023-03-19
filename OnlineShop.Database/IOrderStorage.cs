using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Database
{
    public interface IOrderStorage
    {
        Order TryGetById(Guid orderId);
        void Add(Order order);
        List<Order> GetOrderList();
        void ChangeOrderStatus(Guid orderId, int orderStatus);
        Order TryGetByNumber(int orderNumber);
    }
}