using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApi.Areas.Admin.Models;

namespace OnlineShopWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    [ApiController]
    [Route("[Controller]")]
    public class ModelController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public ModelController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        [HttpPost("AddModel")]
        public IActionResult AddModel(AddModelModel addModelViewModel)
        {
            var mark = databaseContext.Marks.FirstOrDefault(x => x.Name == addModelViewModel.MarkName);
            databaseContext.Models.Add(new Model { Name = addModelViewModel.Name, Mark = mark ?? new Mark { Name = addModelViewModel.MarkName } });
            databaseContext.SaveChanges();
            return new JsonResult("Success");
        }
    }
}
