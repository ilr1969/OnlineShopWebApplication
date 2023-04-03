using System;

namespace OnlineShop.Database.Models
{
    public class OrderDeliveryInfo : Base
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool Agree { get; set; }
        public OrderDeliveryInfo()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}
