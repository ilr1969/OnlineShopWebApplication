using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApplication.Models
{
    public class CartClass
    {
        public string Name;
        public decimal Cost;

        public CartClass(string name, decimal cost, int count)
        {
            Name = name;
            Cost = cost;
        }
    }
}
