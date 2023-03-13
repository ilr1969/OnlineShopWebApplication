﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<Image> Images { get; set; }

        public List<CartItem> CartItems { get; set; }

        public DateTime CreationDateTime { get; set; }

        public Product(Guid id, string name, decimal cost, string description, string image)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            Images = new List<Image>();
            CartItems = new List<CartItem>();
            CreationDateTime = DateTime.Now;
        }

        public Product()
        {
            Images = new List<Image>();
            CartItems = new List<CartItem>();
            CreationDateTime = DateTime.Now;
        }
    }
}
