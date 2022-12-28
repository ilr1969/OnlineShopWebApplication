using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class ProductStorage
    {
        public static List<ProductClass> productsList = new List<ProductClass>()
        {
            new ProductClass("Ferrari", 15000000, "good"),
            new ProductClass("Lambo", 25000000, "best"),
            new ProductClass("Camaro", 5000000, "good"),
            new ProductClass("Mustang", 7000000, "good"),
        };

        public List<ProductClass> GetAll()
        {
            return productsList;
        }

        public string TryGetByID(int id)
        {
            try
            {
                return productsList.First(product => product.ID == id).ToString();
            }
            catch (System.Exception)
            {
                return "Такого товара не существует!";
            }
        }
    }
}
