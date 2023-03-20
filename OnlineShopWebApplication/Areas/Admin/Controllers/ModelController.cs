using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using System.Linq;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public ModelController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        public IActionResult Add()
        {
            SelectList marks = new(databaseContext.Marks.Select(x => x.Name).ToList(), "MarkName");
            ViewBag.Marks = marks;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddModel(AddModelViewModel addModelViewModel)
        {
            try
            {
                var mark = databaseContext.Marks.FirstOrDefault(x => x.Name == addModelViewModel.MarkName);
                databaseContext.Models.Add(new Model { Name = addModelViewModel.Name, Mark = mark });
                databaseContext.SaveChanges();
                return RedirectToAction("models", "admin");
            }
            catch
            {
                return View("Add");
            }
        }
    }
}
