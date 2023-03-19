using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using System.Linq;

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
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = userRole.Name };
                var result = roleManager.CreateAsync(role).Result;
                if (result.Succeeded)
                {
                    return Redirect("/admin/admin/userroles");
                }
                else
                {
                    var error = result.Errors.First().Description;
                    ModelState.AddModelError("Name", error);
                    return View("AddUserRole", userRole);
                }
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
