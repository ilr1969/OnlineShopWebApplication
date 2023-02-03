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

        // GET: UserController/Details/5
        public ActionResult Login(string name, string password)
        {
            var user = userStorage.TryGetUser(name);
            if (user != null && user.Password == password)
            {
                Constants.UserId = name;
                return Redirect("/home/index");
            }
            return View("LoginForm");
        }

        // GET: UserController/Create
        public ActionResult Register(string name, string password1, string password2)
        {
            var user = userStorage.TryGetUser(name);
            if (user == null)
            {
                userStorage.AddUser(new UserClass(name, password1));
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
