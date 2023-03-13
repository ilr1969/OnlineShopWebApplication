using System;

namespace OnlineShop.Database.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}