using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Database.Models
{
    public class Order : Base
    {
        static int OrderCounter = 1;
        public int OrderNumber { get; set; }
        public string UserName { get; set; }
        public OrderStatus Status { get; set; }
        public List<CartItems> CartItems { get; set; }
        public OrderDeliveryInfo DeliveryInfo { get; set; }

        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }

        public Order()
        {
            OrderNumber = OrderCounter;
            OrderCounter++;
            CreationDateTime = DateTime.Now;
            Status = OrderStatus.Created;
            CartItems = new List<CartItems>();
        }
    }
}
