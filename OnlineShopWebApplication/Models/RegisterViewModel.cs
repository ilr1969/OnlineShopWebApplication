using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя не может быть короче 3 символов содержать только латинские буквы")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Почта обязательна")]
        [EmailAddress(ErrorMessage = "Указан некорректный адрес почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Пароль должен быть не менее 8 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтверждение пароля обязательно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ComparePassword { get; set; }
    }
}
