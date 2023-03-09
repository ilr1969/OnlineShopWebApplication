using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    public class UserRoleController : Controller
    {
        IUserRoleStorage userRoleStorage;

        public UserRoleController(IUserRoleStorage userRoleStorage)
        {
            this.userRoleStorage = userRoleStorage;
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
        public IActionResult AddRole(UserRoleViewModel userRole)
        {
            var userRoleList = userRoleStorage.GetRolesList();
            if (ModelState.IsValid && userRoleList.FirstOrDefault(x => x.RoleName == userRole.RoleName) == null)
            {
                userRoleStorage.AddUserRole(userRole);
                return Redirect("/admin/admin/userroles");
            }
            return View("AddUserRole");
        }

        // GET: UserRoleController/EditUserRole/5
        public ActionResult EditUserRole(Guid userRoleId)
        {
            var UserRoleToEdit = userRoleStorage.GetRole(userRoleId);
            return View(UserRoleToEdit);
        }

        [HttpPost]
        public ActionResult SaveRole(Guid userRoleId, string roleName, string roleDescription)
        {
            userRoleStorage.UpdateRole(userRoleId, roleName, roleDescription);
            return Redirect("/admin/admin/userroles");
        }

        // GET: UserRoleController/RemoveUserRole/5
        public ActionResult RemoveUserRole(Guid userRoleId)
        {
            var UserRoleToRemove = userRoleStorage.GetRole(userRoleId);
            userRoleStorage.RemoveUserRole(UserRoleToRemove);
            return Redirect("/admin/admin/userroles");
        }
    }
}
