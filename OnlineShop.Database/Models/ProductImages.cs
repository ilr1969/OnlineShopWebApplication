﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Database.Models
{
    public class ProductImages
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }
        public ProductImages(Guid id, string name, Guid productId)
        {
            Id = id;
            Name = name;
            ProductId = productId;
        }
        public ProductImages()
        {

        }
    }
}
