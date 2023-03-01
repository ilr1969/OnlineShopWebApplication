using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Helpers
{
    public class ToViewModelConverter
    {
        public ProductViewModel ProductToViewModel(Product product)
        {
            var productViewModel = new ProductViewModel
            {
                ID = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImagePath = product.ImagePath
            };
            return productViewModel;
        }

        public List<ProductViewModel> ProductsToViewModel(List<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();
            foreach (var prod in products)
            {
                var productViewModel = new ProductViewModel();
                productViewModel.ID = prod.Id;
                productViewModel.Name = prod.Name;
                productViewModel.Description = prod.Description;
                productViewModel.Cost = prod.Cost;
                productViewModel.ImagePath = prod.ImagePath;
                productsViewModel.Add(productViewModel);
            }
            return productsViewModel;
        }

        public CartViewModel CartToViewModel(Cart cart)
        {
            var cartViewModel = new CartViewModel();
            if (cart != null)
            {
                cartViewModel.Id = cart.Id;
                cartViewModel.UserID = cart.UserID;
                cartViewModel.CartItems = CartItemsToViewModel(cart.CartItems);
            }
            return cartViewModel;
        }

        public List<CartItemViewModel> CartItemsToViewModel(List<CartItem> cartItems)
        {
            var cartItemsViewModel = new List<CartItemViewModel>();
            foreach (var item in cartItems)
            {
                var cartItemViewModel = new CartItemViewModel();
                cartItemViewModel.Id = item.Id;
                cartItemViewModel.Product = ProductToViewModel(item.Product);
                cartItemViewModel.Count = item.Count;
                cartItemsViewModel.Add(cartItemViewModel);
            }
            return cartItemsViewModel;
        }
    }
}
