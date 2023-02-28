using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApplication.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal FullCost
        {
            get
            {
                return CartItems?.Sum(x => x.Cost) ?? 0;
            }
        }
        public decimal Amount
        {
            get
            {
                return CartItems?.Sum(x => x.Count) ?? 0;
            }
        }
    }
}
