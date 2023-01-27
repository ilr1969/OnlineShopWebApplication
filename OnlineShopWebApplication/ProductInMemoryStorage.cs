using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class ProductInMemoryStorage : IProductStorage
    {
        public static List<ProductClass> productsList = new List<ProductClass>()
        {
            new ProductClass("Ferrari", 15000000, "good", "/images/image1.jpg"),
            new ProductClass("Lambo", 25000000, "best", "/images/image2.jpg"),
            new ProductClass("Camaro", 5000000, "good", "/images/image3.jpg"),
            new ProductClass("Mustang", 7000000, "good", "/images/image4.jpg"),
            new ProductClass("Volga", 7000, "not bad", "/images/image5.jpg"),
            new ProductClass("Kopeyka", 700, "foo", "/images/image6.jpg"),
        };

        public ProductClass TryGetById(int productId)
        {
            return productsList.FirstOrDefault(product => product.ID == productId);
        }

        public List<ProductClass> GetAll()
        {
            return productsList;
        }
    }
}
