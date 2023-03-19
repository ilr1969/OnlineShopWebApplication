using OnlineShop.Database.Models;
using System;

namespace OnlineShopWebApplication.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
        public Cart UserCart { get; set; }
        public decimal Cost
        {
            get
            {
                return Product.Cost * Count;
            }
        }
    }
}