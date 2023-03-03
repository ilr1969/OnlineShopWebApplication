using System;
using System.Collections.Generic;
using OnlineShop.Database.Models;

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