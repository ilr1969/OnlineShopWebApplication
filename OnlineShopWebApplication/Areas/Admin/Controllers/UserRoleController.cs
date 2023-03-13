﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class UserRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: UserRoleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserRoleController/AddUserRole
        public ActionResult AddUserRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(IdentityRole userRole)
        {
            
            if (roleManager.Roles.FirstOrDefault(x => x.Name == userRole.Name) == null)
            {
                var role = new IdentityRole { Name = userRole.Name };
                roleManager.CreateAsync(role).Wait();
                return Redirect("/admin/admin/userroles");
            }
            return View("AddUserRole");
        }

        // GET: UserRoleController/RemoveUserRole/5
        public ActionResult RemoveUserRole(string userRoleId)
        {
            var userRoleToRemove = roleManager.Roles.First(x => x.Id == userRoleId);
            roleManager.DeleteAsync(userRoleToRemove);
            return Redirect("/admin/admin/userroles");
        }
    }
}
