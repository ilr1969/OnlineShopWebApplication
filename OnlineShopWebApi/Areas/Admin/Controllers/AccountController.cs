using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Database;
using OnlineShop.Database.Models;
using OnlineShopWebApi;
using OnlineShopWebApi.Areas.Admin.Models;
using OnlineShopWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShopWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Roles = Constants.AdminRole)]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: UserController/Add
        [HttpPost("AddUser")]
        public ActionResult AddUser(AddUserModel addUserModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User { UserName = addUserModel.UserName, Email = addUserModel.Email };
                var result = userManager.CreateAsync(newUser, addUserModel.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, Constants.UserRole).Wait();
                    return Ok();
                }
            }
            return BadRequest();
        }

        // GET: UserController/removeUser/5
        [HttpDelete("DeleteUser")]
        public ActionResult RemoveUser(string userName)
        {
            var userToRemove = userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (userToRemove == null)
            {
                return NotFound();
            }
            if (userToRemove.UserName != "Admin")
            {
                userManager.DeleteAsync(userToRemove).Wait();
                return Ok();
            }
            return BadRequest();
        }

        // GET: UserController/Login
        [AllowAnonymous]
        [HttpPost("Authorize")]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false).Result;
                if (result.Succeeded)
                {
                    var userToken = GenerateJwtToken(loginModel.UserName);
                    return Ok(new { token = userToken, Message = "Success" });
                }
            }
            return BadRequest();
        }

        private string GenerateJwtToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthOptions.KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserName", userName) }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = AuthOptions.ISSUER,
                Audience = AuthOptions.AUDIENCE,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}