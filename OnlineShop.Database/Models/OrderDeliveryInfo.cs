using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Database.Models
{
    public class OrderDeliveryInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool Agree { get; set; }
    }
}
