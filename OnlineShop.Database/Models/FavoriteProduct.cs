using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Database.Models
{
    public class FavoriteProduct
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<FavoriteItem> FavoriteItems { get; set; }
        public FavoriteProduct()
        {
            FavoriteItems = new List<FavoriteItem>();
        }
    }
}
