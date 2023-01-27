using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApplication.Models
{
    public class CartClass
    {
        public Guid Id;
        public string UserID;
        public List<CartItem> CartItems;
        public decimal FullCost
        {
            get
            {
                return CartItems.Sum(x => x.Cost);
            }
        }
    }
}
