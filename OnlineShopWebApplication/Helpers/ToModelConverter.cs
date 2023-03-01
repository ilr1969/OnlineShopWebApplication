using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Helpers
{
    public class ToModelConverter
    {
        public static Product ProductToModel(ProductViewModel productviewmodel)
        {
            var product = new Product
            {
                Id = productviewmodel.ID,
                Name = productviewmodel.Name,
                Description = productviewmodel.Description,
                Cost = productviewmodel.Cost,
                ImagePath = productviewmodel.ImagePath
            };
            return product;
        }
    }
}
