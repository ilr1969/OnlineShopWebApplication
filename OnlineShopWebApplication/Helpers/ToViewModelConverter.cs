using System;
using System.Collections.Generic;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Helpers
{
    public static class ToViewModelConverter
    {
        public static ProductViewModel ToProductViewModel(this Product product)
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

        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            var editProductViewModel = new EditProductViewModel
            {
                ID = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
            };
            return editProductViewModel;
        }

        public static List<ProductViewModel> ToProductsViewModel(this List<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();
            foreach (var prod in products)
            {
                productsViewModel.Add(prod.ToProductViewModel());
            }
            return productsViewModel;
        }

        public static List<OrderViewModel> ToOrdersViewModel(this List<Order> orders)
        {
            var ordersViewModel = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                ordersViewModel.Add(order.ToOrderViewModel());
            }
            return ordersViewModel;
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            var orderViewModel = new OrderViewModel()
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CartItems = order.CartItems.ToCartItemsViewModel(),
                DeliveryInfo = order.DeliveryInfo.ToOrderDeliveryInfoViewModel(),
                CreationDatetime = order.CreationDatetime,
                Status = (OrderStatusViewModel)(int)order.Status
            };
            return orderViewModel;
        }

        public static OrderDeliveryInfoViewModel ToOrderDeliveryInfoViewModel(this OrderDeliveryInfo orderDeliveryInfo)
        {
            var orderDeliveryInfoViewModel = new OrderDeliveryInfoViewModel()
            {
                Id = orderDeliveryInfo.Id,
                Name = orderDeliveryInfo.Name,
                Address = orderDeliveryInfo.Address,
                Phone = orderDeliveryInfo.Phone,
                Agree = orderDeliveryInfo.Agree,
            };
            return orderDeliveryInfoViewModel;
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            var cartViewModel = new CartViewModel();
            if (cart != null)
            {
                cartViewModel.Id = cart.Id;
                cartViewModel.UserID = cart.UserID;
                cartViewModel.CartItems = cart.CartItems.ToCartItemsViewModel();
            }
            return cartViewModel;
        }

        public static List<CartItemViewModel> ToCartItemsViewModel(this List<CartItem> cartItems)
        {
            var cartItemsViewModel = new List<CartItemViewModel>();
            foreach (var item in cartItems)
            {
                var cartItemViewModel = new CartItemViewModel
                {
                    Id = item.Id,
                    Product = item.Product.ToProductViewModel(),
                    Count = item.Count,
                };
                cartItemsViewModel.Add(cartItemViewModel);
            }
            return cartItemsViewModel;
        }
    }
}
