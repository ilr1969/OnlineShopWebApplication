using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Database.Models
{
    public class CompareProduct
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CompareItem> CompareItems { get; set; }
        public CompareProduct()
        {
            CompareItems = new List<CompareItem>();
        }
    }
}
