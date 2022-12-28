using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApplication.Models
{
    public class GoodsClass
    {
        private static int ID_counter = 1;
        public int ID;
        public string Name;
        public decimal Cost;
        public string Description;

        public GoodsClass(string name, int cost, string descr)
        {
            ID = ID_counter;
            Name = name;
            Cost = cost;
            Description = descr;
            ID_counter++;
        }

        public override string ToString()
        {
            return $"{ID}\n{Name}\n{Cost}\n{Description}".ToString();
        }
    }
}
