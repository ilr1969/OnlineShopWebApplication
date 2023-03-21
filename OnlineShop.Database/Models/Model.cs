using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Database.Models
{
    public class Model
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MarkId { get; set; }
        public Mark Mark { get; set; }
        public List<Product> Products { get; set; }
    }
}
