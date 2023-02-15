using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class ProductInMemoryStorage : IProductStorage
    {
        public List<ProductClass> productsList = new List<ProductClass>()
        {
            new ProductClass() {Name = "Ferrari", Cost = 15000000, Description = "good", ImagePath = "/images/image1.jpg" },
            new ProductClass() {Name = "Lambo", Cost = 25000000, Description = "best", ImagePath = "/images/image2.jpg" },
            new ProductClass() {Name = "Camaro", Cost = 5000000, Description = "good", ImagePath = "/images/image3.jpg" },
            new ProductClass() {Name = "Mustang", Cost = 7000000, Description = "good", ImagePath = "/images/image4.jpg" },
            new ProductClass() {Name = "Volga", Cost = 7000, Description = "not bad", ImagePath = "/images/image5.jpg" },
            new ProductClass() {Name = "Kopeyka", Cost = 700, Description = "foo", ImagePath = "/images/image6.jpg" },
        };

        public ProductClass TryGetById(Guid productId)
        {
            return productsList.FirstOrDefault(product => product.ID == productId);
        }

        public List<ProductClass> GetAll()
        {
            return productsList;
        }
    }
}
