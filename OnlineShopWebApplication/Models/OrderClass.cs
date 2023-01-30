using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApplication.Models
{
    public class OrderClass
    {
        public Guid Id;
        public string UserId;
        public List<IOrderStorage> orderStorage;
    }
}
