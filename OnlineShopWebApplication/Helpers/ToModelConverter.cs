using OnlineShop.Database.Models;
using OnlineShopWebApplication.Models;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Helpers
{
    public static class ToModelConverter
    {
        public static Product ToProduct(this ProductViewModel productviewmodel)
        {
            var product = new Product
            {
                Id = productviewmodel.Id,
                Name = productviewmodel.Name,
                Description = productviewmodel.Description,
                Cost = productviewmodel.Cost,
                ProductImages = productviewmodel.ProductImages
            };
            return product;
        }

        public static List<Order> ToOrders(this List<OrderViewModel> ordersViewModel)
        {
            var orders = new List<Order>();
            foreach (var order in ordersViewModel)
            {
                orders.Add(order.ToOrder());
            }
            return orders;
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            var order = new Order()
            {
                Id = orderViewModel.Id,
                OrderNumber = orderViewModel.OrderNumber,
                CartItems = orderViewModel.CartItems.ToCartItems(),
                DeliveryInfo = orderViewModel.DeliveryInfo.ToOrderDeliveryInfo(),
                CreationDateTime = orderViewModel.CreationDatetime,
                Status = (OrderStatus)(int)orderViewModel.Status,
                UserName = orderViewModel.UserName
            };
            return order;
        }

        public static OrderDeliveryInfo ToOrderDeliveryInfo(this OrderDeliveryInfoViewModel orderDeliveryInfoViewModel)
        {
            var orderDeliveryInfo = new OrderDeliveryInfo
            {
                Id = orderDeliveryInfoViewModel.Id,
                Name = orderDeliveryInfoViewModel.Name,
                Address = orderDeliveryInfoViewModel.Address,
                Phone = orderDeliveryInfoViewModel.Phone,
                Agree = orderDeliveryInfoViewModel.Agree,
            };
            return orderDeliveryInfo;
        }

        public static Cart ToCart(this CartViewModel cartViewModel)
        {
            var cart = new Cart();
            if (cartViewModel != null)
            {
                cart.Id = cartViewModel.Id;
                cart.UserID = cartViewModel.UserID;
                cart.CartItems = cartViewModel.CartItems.ToCartItems();
            }
            return cart;
        }

        public static List<CartItems> ToCartItems(this List<CartItemViewModel> cartItemsViewModel)
        {
            var cartItems = new List<CartItems>();
            foreach (var item in cartItemsViewModel)
            {
                var cartItem = new CartItems
                {
                    Id = item.Id,
                    Product = item.Product.ToProduct(),
                    Count = item.Count,
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
    }
}
