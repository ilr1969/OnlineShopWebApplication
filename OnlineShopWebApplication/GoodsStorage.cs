using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class GoodsStorage
    {
        public static List<GoodsClass> goodsList = new List<GoodsClass>()
        {
            new GoodsClass("Ferrari", 15000000, "good"),
            new GoodsClass("Lambo", 25000000, "best"),
            new GoodsClass("Camaro", 5000000, "good"),
            new GoodsClass("Mustang", 7000000, "good"),
        };
    }
}
