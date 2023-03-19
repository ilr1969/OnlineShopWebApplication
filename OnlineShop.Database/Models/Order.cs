﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class Order
    {
        static int OrderCounter = 1;
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public string UserName { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreationDatetime { get; set; }
        public List<CartItems> CartItems { get; set; }
        public OrderDeliveryInfo DeliveryInfo { get; set; }

        public Order()
        {
            OrderNumber = OrderCounter;
            OrderCounter++;
            Status = OrderStatus.Created;
            CreationDatetime = DateTime.Now;
            CartItems = new List<CartItems>();
        }
    }
}
