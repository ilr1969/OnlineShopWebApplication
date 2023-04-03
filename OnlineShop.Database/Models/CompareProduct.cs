using System;

namespace OnlineShop.Database.Models
{
    public class CompareProduct : Base
    {
        public string UserId { get; set; }
        public Product Product { get; set; }
        public CompareProduct()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}
