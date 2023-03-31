using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Model> Model { get; set; }
        public List<Product> Products { get; set; }
    }
}
