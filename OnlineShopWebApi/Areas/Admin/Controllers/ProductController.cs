using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShopWebApi.Areas.Admin.Models;
using System.Linq;

namespace OnlineShopWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly DatabaseContext databaseContext;
        public ProductController(IProductStorage productStorage, DatabaseContext databaseContext)
        {
            this.productStorage = productStorage;
            this.databaseContext = databaseContext;
        }

        [HttpPut("EditProduct")]
        public IActionResult EditProduct(EditProductModel editProductModel)
        {
            var productToEdit = productStorage.GetAll().FirstOrDefault(x => x.Name == editProductModel.Name);
            if (productToEdit == null)
            {
                return NotFound();
            }
            productToEdit.Name = editProductModel.Name;
            productToEdit.Description = editProductModel.Description;
            productToEdit.Cost = editProductModel.Cost;
            databaseContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("RemoveProduct")]
        public IActionResult Remove(Guid productId)
        {
            productStorage.Remove(productId);
            return Ok();
        }

        [HttpPost("AddProduct")]
        public IActionResult Add(AddProductModel addProductModel)
        {
            if (ModelState.IsValid)
            {
                var mark = databaseContext.Marks.FirstOrDefault(x => x.Name == addProductModel.Mark);
                mark ??= new Mark { Name = addProductModel.Mark };
                databaseContext.Marks.Add(mark);
                var model = databaseContext.Models.FirstOrDefault(x => x.Name == addProductModel.Model);
                model ??= new Model { Name = addProductModel.Model, MarkId = mark.Id };
                databaseContext.Models.Add(model);
                var product = new Product()
                {
                    Name = addProductModel.Mark + " " + addProductModel.Model,
                    Mark = mark,
                    Model = model,
                    Description = addProductModel.Description,
                    Cost = addProductModel.Cost
                };

                productStorage.Add(product);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("AddProductList")]
        public IActionResult AddProductList(List<AddProductModel> addProductModels)
        {
            if (ModelState.IsValid)
            {
                foreach (var prod in addProductModels)
                {
                    var mark = databaseContext.Marks.FirstOrDefault(x => x.Name == prod.Mark);
                    mark ??= new Mark { Name = prod.Mark };
                    databaseContext.Marks.Add(mark);
                    var model = databaseContext.Models.FirstOrDefault(x => x.Name == prod.Model);
                    model ??= new Model { Name = prod.Model, MarkId = mark.Id };
                    databaseContext.Models.Add(model);
                    var product = new Product()
                    {
                        Name = prod.Mark + " " + prod.Model,
                        Mark = mark,
                        Model = model,
                        Description = prod.Description,
                        Cost = prod.Cost
                    };

                    productStorage.Add(product);
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}
