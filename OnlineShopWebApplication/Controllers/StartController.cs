using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class StartController : Controller
    {
        // GET: StartController
        public ActionResult Index()
        {
            return View();
        }

        public string Hello()
        {
            var time = DateTime.Now.Hour;
            switch (time)
            {
                case 0: case 1: case 2: case 3: case 4: case 5: return "Ночь";
                case 6: case 7: case 8: case 9: case 10: case 11: return "Утро";
                case 12: case 13: case 14: case 15: case 16: case 17: return "День";
                case 18: case 19: case 20: case 21: case 22: case 23: return "Вечер";
                default: break;
            }
            return DateTime.Now.ToLongTimeString();
        }


        // GET: StartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
