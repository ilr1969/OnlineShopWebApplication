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
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
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
