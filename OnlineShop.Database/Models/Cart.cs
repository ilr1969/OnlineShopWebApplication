using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Database.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
