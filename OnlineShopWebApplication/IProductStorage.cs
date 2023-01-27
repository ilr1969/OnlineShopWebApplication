using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IProductStorage
    {
        static List<ProductClass> productsList;
        ProductClass TryGetById(int productId);
        List<ProductClass> GetAll();
    }
}
