using OnlineShop.Database.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public List<ProductImages> ProductImages { get; set; }
    }
}
