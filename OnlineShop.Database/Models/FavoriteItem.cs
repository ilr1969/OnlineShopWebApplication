using System;

namespace OnlineShop.Database.Models
{
    public class FavoriteItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public FavoriteProduct FavoriteProduct { get; set; }
    }
}