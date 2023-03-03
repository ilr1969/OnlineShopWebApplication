using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class FavoriteProduct
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
    }
}
