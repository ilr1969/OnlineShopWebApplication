using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserStorage userStorage;

        public UserController(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        // GET: UserController/AddUser
        public ActionResult AddUser()
        {
            return View();
        }

        // GET: UserController/Add
        [HttpPost]
        public ActionResult Add(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                userStorage.AddUser(user.ToUser());
                return Redirect("/admin/admin/users");
            }
            return View("AddUser");
        }

        // GET: UserController/EditUser
        public ActionResult EditUser(Guid userId)
        {
            var userToEdit = userStorage.TryGetUserById(userId);
            return View(userToEdit);
        }

        // POST: UserController/SaveUser
        [HttpPost]
        public ActionResult SaveUser(Guid userId, UserViewModel user)
        {
            userStorage.ChangeUserData(userId, user.ToUser());
            return Redirect("/admin/admin/users");
        }

        // GET: UserController/removeUser/5
        [HttpPost]
        public ActionResult removeUser(Guid userId)
        {
            userStorage.DeleteUser(userId);
            return Redirect("/admin/admin/users");
        }

        // GET: UserController/changePassword/5
        public ActionResult changePassword(Guid userId)
        {
            userStorage.changePassword(userId);
            return Redirect("/admin/admin/users");
        }
    }
}
