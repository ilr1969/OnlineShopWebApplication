﻿using System;

namespace OnlineShop.Database.Models
{
    public class CompareProduct
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
    }
}
