using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using OnlineShopWebApplication.Models;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Helpers
{
    public static class ToViewModelConverter
    {
        public static List<MarkViewModel> ToMarkViewModel(this List<Mark> marks)
        {
            var marksViewModel = new List<MarkViewModel>();
            foreach (var mark in marks)
            {
                var markViewModel = new MarkViewModel { Name = mark.Name };
                marksViewModel.Add(markViewModel);
            }
            return marksViewModel;
        }

        public static List<ModelViewModel> ToModelViewModel(this List<Model> models)
        {
            var modelsViewModel = new List<ModelViewModel>();
            foreach (var model in models)
            {
                var modelViewModel = new ModelViewModel { Name = model.Name };
                modelsViewModel.Add(modelViewModel);
            }
            return modelsViewModel;
        }

        public static Models.ProductViewModel ToProductViewModel(this Product product)
        {
            var productViewModel = new Models.ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Mark = product.Mark?.Name,
                Model = product.Model?.Name,
                Description = product.Description,
                Cost = product.Cost,
                ProductImages = product.ProductImages
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
                ConcurrencyToken = product.ConcurrencyToken,
            };
            return editProductViewModel;
        }

        public static List<Models.ProductViewModel> ToProductsViewModel(this List<Product> products)
        {
            var productsViewModel = new List<Models.ProductViewModel>();
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
                Status = (OrderStatusViewModel)(int)order.Status,
                UserName = order.UserName
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

        public static List<CartItemViewModel> ToCartItemsViewModel(this List<CartItems> cartItems)
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

        public static UserCabinetViewModel ToUserCabinetViewModel(this User user)
        {
            var userCabinetViewModel = new UserCabinetViewModel()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Description = user.Description,
                UserImages = user.UserImages,
            };
            return userCabinetViewModel;
        }

        public static EditUserCabinetViewModel ToEditUserCabinetViewModel(this User user)
        {
            var editUserCabinetViewModel = new EditUserCabinetViewModel()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Description = user.Description,
                Photos = user.UserImages
            };
            return editUserCabinetViewModel;
        }

        public static EditUserViewModel ToEditUserViewModel(this User user)
        {
            var editUserViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Description = user.Description,
                Photos = user.UserImages
            };
            return editUserViewModel;
        }
    }
}
