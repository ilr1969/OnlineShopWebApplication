using System;

namespace OnlineShop.Database.Models
{
    public class CompareItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public CompareProduct CompareProduct { get; set; }
    }
}