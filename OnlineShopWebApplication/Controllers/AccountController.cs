using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly FileUploader fileUploader;
        private readonly DatabaseContext databaseContext;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICartStorage cartStorage, IFavoriteStorage favoriteStorage, ICompareStorage compareStorage, FileUploader fileUploader, DatabaseContext databaseContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cartStorage = cartStorage;
            this.favoriteStorage = favoriteStorage;
            this.compareStorage = compareStorage;
            this.fileUploader = fileUploader;
            this.databaseContext = databaseContext;
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

        public IActionResult UserCabinet(string userName)
        {
            var user = userManager.Users.Where(x => x.UserName == userName).Include(x => x.Photos).FirstOrDefault();
            return View(user.ToUserCabinetViewModel());
        }

        public IActionResult EditUser(string userName)
        {
            var user = userManager.Users.Where(x => x.UserName == userName).Include(x => x.Photos).FirstOrDefault();
            return View(user.ToEditUserCabinetViewModel());
        }

        public IActionResult SaveUser(EditUserCabinetViewModel editUserCabinetViewModel)
        {
            var user = userManager.FindByIdAsync(editUserCabinetViewModel.Id).Result;
            if (ModelState.IsValid)
            {
                if (user.UserName != "Admin")
                {
                    userManager.SetUserNameAsync(user, editUserCabinetViewModel.Name).Wait();
                }
                userManager.SetEmailAsync(user, editUserCabinetViewModel.Email).Wait();
                user.Description = editUserCabinetViewModel.Description;
                userManager.UpdateAsync(user).Wait();

                if (editUserCabinetViewModel.Image != null)
                {
                    var fileName = fileUploader.UploadUserImage(editUserCabinetViewModel.Id.ToString(), editUserCabinetViewModel.Image);
                    user.Photos.Add(new Image { Name = fileName });
                    userManager.UpdateAsync(user).Wait();
                }

                return View("UserCabinet", user.ToUserCabinetViewModel());

            };
            return View("EditUser", editUserCabinetViewModel);
        }
    }
}
