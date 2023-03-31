using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constants.AdminRole)]
    [ApiController]
    [Route("[Controller]")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        readonly IProductStorage productStorage;
        readonly IOrderStorage orderStorage;
        private readonly DatabaseContext databaseContext;

        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DatabaseContext databaseContext)
        {
            this.productStorage = productStorage;
            this.orderStorage = orderStorage;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.databaseContext = databaseContext;
        }

        [HttpGet("GetOrders")]
        public List<Order> Orders()
        {
            return orderStorage.GetOrderList();
        }

        [HttpGet("GetProducts")]
        public List<Product> Products()
        {
            return productStorage.GetAll();
        }

        [HttpGet("GetMarks")]
        public List<Mark> Marks()
        {
            return databaseContext.Marks.ToList();
        }

        [HttpGet("GetModels")]
        public List<Model> Models()
        {
            return databaseContext.Models.ToList();
        }

        [HttpGet("GetUsers")]
        public List<User> Users()
        {
            return userManager.Users.ToList();
        }

        [HttpGet("GetUserRoles")]
        public List<IdentityRole> UserRoles()
        {
            return roleManager.Roles.ToList();
        }
    }
}
