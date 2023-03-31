using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    [ApiController]
    [Route("[Controller]")]
    public class MarkController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public MarkController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        [HttpPost("AddMark")]
        public IActionResult AddMark(string name)
        {
            try
            {
                databaseContext.Marks.Add(new Mark { Name = name });
                databaseContext.SaveChanges();
                return RedirectToAction("marks", "admin");
            }
            catch
            {
                return View("Add");
            }
        }
    }
}
