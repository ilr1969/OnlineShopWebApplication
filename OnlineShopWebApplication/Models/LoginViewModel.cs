using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя не может быть короче 3 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Пароль должен быть не менее 10 символов")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnURL = "/home/index";
    }
}
