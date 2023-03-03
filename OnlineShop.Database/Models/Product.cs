using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public DateTime CreationDateTime { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
            CartItems = new List<CartItem>();
            CreationDateTime = DateTime.Now;
        }
    }
}
