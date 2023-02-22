using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class UserController : Controller
    {
        IUserStorage userStorage;

        public UserController(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        // GET: UserControllerLoginform
        public ActionResult Loginform()
        {
            return View();
        }

        // GET: UserControllerRegsterForm
        public ActionResult RegisterForm()
        {
            return View();
        }

        // GET: UserController/Login
        public ActionResult Login(string name, string password)
        {
            var userFromDatadase = userStorage.TryGetUserByName(name);
            if (userFromDatadase != null && password == userFromDatadase.Password)
            {
                Constants.UserId = name;
                return Redirect("/home/index");
            }
            return View("LoginForm");
        }

        // GET: UserController/Create
        public ActionResult Register(UserClass user)
        {
            if (ModelState.IsValid)
            {
                userStorage.AddUser(user);
                return Redirect("/home/index");
            }
            return View("RegisterForm");
        }

        public ActionResult RegisterError()
        {
            return View();
        }
    }
}
