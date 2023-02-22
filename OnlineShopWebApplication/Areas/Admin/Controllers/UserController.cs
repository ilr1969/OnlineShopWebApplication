﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IUserStorage userStorage;

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
        public ActionResult Add(UserClass user)
        {
            if (ModelState.IsValid)
            {
                userStorage.AddUser(user);
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
        public ActionResult SaveUser(Guid userId, UserClass user)
        {
            userStorage.ChangeUserData(userId, user);
            return Redirect("/admin/admin/users");
        }

        // GET: UserController/removeUser/5
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