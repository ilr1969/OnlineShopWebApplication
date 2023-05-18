using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineShop.Database;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShop.Database.Storages;
using OnlineShopWebApplication.Controllers;

namespace OnlineShop.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void Test_FindProduct_Index()
        {
            var mock = new Mock<IProductStorage>();
            mock.Setup(x => x.GetAll()).Returns(products);
            var controller = new ProductController(mock.Object);

            var result = controller.Index(new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"));

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);
            Assert.Equal(products.Count, model.Count());
/*            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.Equal(products.Count, model.Count());*/
        }

        public List<Product> products = new()
        {
            new Product(new Guid("8a5cf474-c473-48e1-bc3e-bbe0f22a80f2"), "Ferrari", 35000000, "super" ),
            new Product(new Guid("e6d46e32-765c-487d-bf57-78759b32a47c"), "Lambo", 25000000, "best" ),
            new Product(new Guid("59d7a46d-79a2-4a09-b6ad-a2333c3d3dcc"), "Camaro", 5000000, "good" ),
            new Product(new Guid("b41fefb9-1c66-4f2a-86af-090ada282060"), "Mustang", 7000000, "good" ),
            new Product(new Guid("36211d90-17e0-42d0-9f3b-3b17d2885ec1"), "Volga", 7000, "not bad" ),
            new Product(new Guid("968bfe01-31ba-44c0-a7c8-d1d04c1ffeb5"), "Kopeyka", 700, "foo" ),
        };
    }
}