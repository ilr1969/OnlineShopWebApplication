using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class ProductDbStorage : IProductStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /*        public List<Product> productsList = new List<Product>()
                {
                    new Product() {Name = "Ferrari", Cost = 15000000, Description = "good", ImagePath = "/images/image1.jpg" },
                    new Product() {Name = "Lambo", Cost = 25000000, Description = "best", ImagePath = "/images/image2.jpg" },
                    new Product() {Name = "Camaro", Cost = 5000000, Description = "good", ImagePath = "/images/image3.jpg" },
                    new Product() {Name = "Mustang", Cost = 7000000, Description = "good", ImagePath = "/images/image4.jpg" },
                    new Product() {Name = "Volga", Cost = 7000, Description = "not bad", ImagePath = "/images/image5.jpg" },
                    new Product() {Name = "Kopeyka", Cost = 700, Description = "foo", ImagePath = "/images/image6.jpg" },
                };*/

        public Product TryGetById(Guid productId)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == productId);
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Remove(Guid productId)
        {
            databaseContext.Products.Remove(TryGetById(productId));
            databaseContext.SaveChanges();
        }
    }
}
