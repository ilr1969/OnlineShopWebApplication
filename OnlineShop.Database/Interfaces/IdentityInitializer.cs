using Microsoft.AspNetCore.Identity;
using OnlineShop.Database.Models;

namespace OnlineShop.Database.Interfaces
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminName = "Admin";
            var adminEmail = "1@1.ru";
            var adminPass = "1q2W3e4R_";
            if (roleManager.FindByNameAsync(Constants.AdminRole).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.AdminRole)).Wait();
            }
            if (roleManager.FindByNameAsync(Constants.UserRole).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.UserRole)).Wait();
            }
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminName };
                var result = userManager.CreateAsync(admin, adminPass).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constants.AdminRole).Wait();
                }
            }
        }
    }
}
