using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Areas.Admin.Models;
using OnlineShopWebApplication.Controllers;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: UserController/AddUser
        public ActionResult AddUser()
        {
            return View();
        }

        // GET: UserController/Add
        [HttpPost]
        public ActionResult Add(RegisterViewModel registerViewModel)
        {
            var user = new User { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
            var result = userManager.CreateAsync(user, registerViewModel.Password).Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, Constants.UserRole).Wait();
            }
            return Redirect("/admin/admin/users");
        }

        // GET: UserController/EditUser
        public ActionResult EditUser(string userId)
        {
            return View(userManager.Users.First(x => x.Id == userId));
        }

        // POST: UserController/SaveUser
        [HttpPost]
        public ActionResult SaveUser(string userId, User user)
        {
            var userToEdit = userManager.Users.First(x => x.Id == userId);
            userManager.SetEmailAsync(userToEdit, user.Email).Wait();
            if (userToEdit.UserName != "Admin")
            {
                userManager.SetUserNameAsync(userToEdit, user.UserName).Wait();
            }
            return Redirect("/admin/admin/users");
        }

        // GET: UserController/removeUser/5
        [HttpPost]
        public ActionResult RemoveUser(string userId)
        {
            var userToRemove = userManager.Users.First(x => x.Id == userId);
            if (userToRemove.UserName != "Admin")
            {
                userManager.DeleteAsync(userToRemove).Wait();
            }
            return Redirect("/admin/admin/users");
        }

        // GET: UserController/changePassword/5
        public ActionResult ChangePassword(string userId)
        {
            return View(new PasswordViewModel { Id = userId });
        }

        // GET: UserController/savePassword/5
        [HttpPost]
        public ActionResult SavePassword(PasswordViewModel passwordViewModel)
        {
            if (ModelState.IsValid)
            {
                var userToChange = userManager.Users.First(x => x.Id == passwordViewModel.Id);
                userManager.RemovePasswordAsync(userToChange).Wait();
                userManager.AddPasswordAsync(userToChange, passwordViewModel.Password).Wait();
                userManager.UpdateAsync(userToChange).Wait();
                return Redirect("/admin/admin/users");
            }
            return Redirect("/admin/admin/users");
        }

        // GET: UserRoleController/editUserRole/5
        public IActionResult EditUserRole(string userId)
        {
            var user = userManager.FindByIdAsync(userId).Result;
            var userRoles = userManager.GetRolesAsync(user).Result.ToList();
            var allRoles = roleManager.Roles.ToList();
            var model = new ChangeRoleViewModel
            {
                UserId = userId,
                AllRoles = allRoles,
                UserEmail = user.Email,
                UserRoles = userRoles,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveRole(string userId, List<string> roles)
        {
            var user = userManager.FindByIdAsync(userId).Result;
            if (user.UserName == "Admin")
            {
                roles.Add(Constants.AdminRole);
            }
            var userRoles = userManager.GetRolesAsync(user).Result.ToList();
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);

            userManager.AddToRolesAsync(user, addedRoles).Wait();
            userManager.RemoveFromRolesAsync(user, removedRoles).Wait();
            return Redirect("/admin/admin/users");
        }
    }
}
