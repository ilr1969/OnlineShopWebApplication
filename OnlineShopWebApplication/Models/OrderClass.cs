using System;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Models
{
    public class OrderClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string UserID;
        public List<CartItem> CartItems;
        public decimal FullCost;
        public OrderClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
