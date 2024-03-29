﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

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
