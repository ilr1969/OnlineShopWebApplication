using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Database;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;
using OnlineShopWebApplication.Helpers;
using OnlineShopWebApplication.Models;
using System.Linq;

namespace OnlineShopWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly ICompareStorage compareStorage;
        private readonly IFavoriteStorage favoriteStorage;
        private readonly IOrderStorage orderStorage;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly FileUploader fileUploader;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICartStorage cartStorage, FileUploader fileUploader, IOrderStorage orderStorage, ICompareStorage compareStorage, IFavoriteStorage favoriteStorage)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cartStorage = cartStorage;
            this.fileUploader = fileUploader;
            this.orderStorage = orderStorage;
            this.compareStorage = compareStorage;
            this.favoriteStorage = favoriteStorage;
        }

        // GET: UserControllerLoginform
        public ActionResult LoginForm(string returnURL)
        {
            return View(new LoginViewModel { ReturnURL = returnURL ?? "/home/index" });
        }

        // GET: UserControllerRegsterForm
        public ActionResult RegisterForm(string returnURL)
        {
            return View(new RegisterViewModel { ReturnURL = returnURL ?? "/home/index" });
        }

        // GET: UserController/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var tempUserId = Request.Cookies["TempUser"];
            var unregisteredUserCartItems = cartStorage.TryGetByUserId(tempUserId).CartItems;
            var unregisteredUserFavoriteList = favoriteStorage.GetAll(tempUserId);
            var unregisteredUserCompareList = compareStorage.GetAll(tempUserId);
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    cartStorage.TransferProductsOnLogin(loginViewModel.UserName, unregisteredUserCartItems, tempUserId);
                    favoriteStorage.TransferFavoriteListOnLogin(loginViewModel.UserName, unregisteredUserFavoriteList, tempUserId);
                    compareStorage.TransferCompareListOnLogin(loginViewModel.UserName, unregisteredUserCompareList, tempUserId);
                    return Redirect(loginViewModel.ReturnURL);
                }
                else
                {
                    return View("LoginForm", loginViewModel);
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
                else
                {
                    var errorList = result.Errors.Select(x => x.Description).ToList();
                    var errors = string.Join('\n', errorList);
                    ModelState.AddModelError("Errors", errors);
                    return View("RegisterForm", registerViewModel);
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
            var user = userManager.Users.Where(x => x.UserName == userName).Include(x => x.UserImages).FirstOrDefault();
            var userCart = cartStorage.TryGetByUserId(user.Id);
            var userOrders = orderStorage.GetOrderList().Where(x => x.UserName == userName).ToList();
            var userCabinet = new UserCabinetViewModel()
            {
                Id = user.Id,
                Name = user.UserName,
                Description = user.Description,
                Email = user.Email,
                UserImages = user.UserImages,
                Orders = userOrders.ToOrdersViewModel()
            };
            return View(userCabinet);
        }

        public IActionResult EditUser(string userName)
        {
            var user = userManager.Users.Where(x => x.UserName == userName).Include(x => x.UserImages).FirstOrDefault();
            return View(user.ToEditUserCabinetViewModel());
        }

        public IActionResult SaveUser(EditUserCabinetViewModel editUserCabinetViewModel)
        {
            var user = userManager.Users.Where(x => x.Id == editUserCabinetViewModel.Id).Include(x => x.UserImages).FirstOrDefault();
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
                    user.UserImages.Clear();
                    user.UserImages.Add(new UserImages { Name = fileName });
                    userManager.UpdateAsync(user).Wait();
                }

                return View("UserCabinet", user.ToUserCabinetViewModel());

            };
            return View("EditUser", editUserCabinetViewModel);
        }
    }
}
