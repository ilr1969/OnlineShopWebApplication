using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class OrderDbStorage : IOrderStorage
    {
        private readonly DatabaseContext databaseContext;

        public OrderDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Order TryGetById(Guid orderId)
        {
            return databaseContext.Orders.Include(x => x.DeliveryInfo).Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == orderId);
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

        public void ChangeOrderStatus(Guid orderId, int orderStatus)
        {
            var orderToChange = TryGetById(orderId);
            orderToChange.Status = (OrderStatus)orderStatus;
            databaseContext.SaveChanges();
        }

        public List<Order> GetOrderList()
        {
            return databaseContext.Orders.Include(x => x.CartItems).ThenInclude(x => x.Product).Include(x => x.DeliveryInfo).ToList();
        }

        public Order TryGetByNumber(int orderNumber)
        {
            return databaseContext.Orders.Include(x => x.CartItems).ThenInclude(x => x.Product).Include(x => x.DeliveryInfo).FirstOrDefault(x => x.OrderNumber == orderNumber);
        }
    }
}
