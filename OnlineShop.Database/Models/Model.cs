using System;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class Model : Base
    {
        public string Name { get; set; }
        public Guid MarkId { get; set; }
        public Mark Mark { get; set; }
        public List<Product> Products { get; set; }
        public Model()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}
