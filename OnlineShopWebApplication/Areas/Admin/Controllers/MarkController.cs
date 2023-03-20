using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using System.Linq;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarkController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public MarkController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
