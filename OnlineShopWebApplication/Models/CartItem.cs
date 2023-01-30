using System;

namespace OnlineShopWebApplication.Models
{
    public class CartItem
    {
        public Guid Id;
        public ProductClass Product;
        public int Count;
        public decimal Cost
        {
            get
            {
                return Product.Cost * Count;
            }
        }
        public override string ToString()
        {
            return $"{Product.Name}; {Count}; {Cost}; {Product.Description} \n";
        }
    }
}