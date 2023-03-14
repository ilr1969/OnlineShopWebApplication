using System;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public static int OrderCounter = 0;
        public int OrderNumber { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public DateTime CreationDatetime { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public OrderDeliveryInfoViewModel DeliveryInfo { get; set; }
    }
}
