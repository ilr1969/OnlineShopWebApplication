using System;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public int OrderNumber { get; set; }
        public string UserName { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public DateTime CreationDatetime { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public OrderDeliveryInfoViewModel DeliveryInfo { get; set; }
    }
}
