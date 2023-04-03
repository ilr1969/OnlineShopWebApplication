using System;

namespace OnlineShop.Database.Models
{
    public class FavoriteProduct : Base
    {
        public string UserId { get; set; }
        public Product Product { get; set; }
        public FavoriteProduct()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}
