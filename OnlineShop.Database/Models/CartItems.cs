using System;

namespace OnlineShop.Database.Models
{
    public class CartItems : Base
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public CartItems()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}