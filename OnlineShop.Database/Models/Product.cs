﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Database.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public string Description { get; set; }

        public List<ProductImages> ProductImages { get; set; }

        public List<CartItems> CartItems { get; set; }

        public DateTime CreationDateTime { get; set; }

        public Product(Guid id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            ProductImages = new List<ProductImages>();
            CartItems = new List<CartItems>();
            CreationDateTime = DateTime.Now;
        }

        public Product()
        {
            ProductImages = new List<ProductImages>();
            CartItems = new List<CartItems>();
            CreationDateTime = DateTime.Now;
        }
    }
}
