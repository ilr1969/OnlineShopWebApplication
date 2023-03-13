using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly IFavoriteStorage favoriteStorage;
        private readonly ICompareStorage compareStorage;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICartStorage cartStorage, IFavoriteStorage favoriteStorage, ICompareStorage compareStorage)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cartStorage = cartStorage;
            this.favoriteStorage = favoriteStorage;
            this.compareStorage = compareStorage;
        }

        // GET: UserControllerLoginform
        public ActionResult LoginForm(string returnURL)
        {
            return View(new LoginViewModel { ReturnURL = returnURL });
        }

        // GET: UserControllerRegsterForm
        public ActionResult RegisterForm(string returnURL)
        {
            return View(new RegisterViewModel { ReturnURL = returnURL });
        }

        // GET: UserController/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
/*            var unregisteredUserCartItems = cartStorage.TryGetByUserId(userManager.GetUserId(HttpContext.User)).CartItems;
            var unregisteredUserFavoriteList = favoriteStorage.GetAll(userManager.GetUserId(HttpContext.User));
            var unregisteredUserCompareList = compareStorage.GetAll(userManager.GetUserId(HttpContext.User));*/
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
/*                    cartStorage.TransferProductsOnLogin(loginViewModel.UserName, unregisteredUserCartItems);
                    favoriteStorage.TransferFavoriteListOnLogin(loginViewModel.UserName, unregisteredUserFavoriteList);
                    compareStorage.TransferCompareListOnLogin(loginViewModel.UserName, unregisteredUserCompareList);*/
                    return Redirect(loginViewModel.ReturnURL);
                }
            }
            return View(loginViewModel);
        }

        // GET: UserController/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
                var result = userManager.CreateAsync(newUser, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, Constants.UserRole).Wait();
                    return Redirect(registerViewModel.ReturnURL);
                }
            }
            return View("RegisterForm");
        }

        public ActionResult RegisterError()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            signInManager.SignOutAsync().Wait();
            return Redirect("/home/index");
        }
    }
}
