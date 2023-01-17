using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class CartStorage
    {
        public Dictionary<CartClass, int> productsList = new Dictionary<CartClass, int>();

        public Dictionary<CartClass, int> GetCart()
        {
            return productsList;
        }

        public void AddToCart(CartClass product)
        {
            if (productsList.Where(prod => prod.Key.Name == product.Name).Count() == 1)
            {
                productsList[productsList.First(prod => prod.Key.Name == product.Name).Key]++;
            }
            else
            {
                productsList[product] = 1;
            }
        }
    }
}
