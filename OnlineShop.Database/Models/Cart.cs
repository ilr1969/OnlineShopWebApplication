using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class Cart : Base
    {
        public string UserID { get; set; }
        public List<CartItems> CartItems { get; set; }
        public Cart()
        {
            CartItems = new List<CartItems>();
            CreationDateTime = DateTime.Now;
        }
    }
}
