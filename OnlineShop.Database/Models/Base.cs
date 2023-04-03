using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Database.Models
{
    public class Base
    {
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime EditDateTime { get; set; }
    }
}
