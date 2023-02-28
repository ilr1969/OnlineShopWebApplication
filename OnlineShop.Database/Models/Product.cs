﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Database.Models
{
    public class Product
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
        }
    }
}
