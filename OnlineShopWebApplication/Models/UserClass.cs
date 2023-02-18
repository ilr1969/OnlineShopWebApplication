using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class UserClass
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя не может быть короче 3 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Почта обязательна")]
        [EmailAddress(ErrorMessage = "Указан некорректный адрес почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите возраст")]
        [Range(18, 60, ErrorMessage = "Вам должно быть не менее 18 лет")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Пароль должен быть не менее 10 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтверждение пароля обязательно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ComparePassword { get; set; }

        public UserClass()
        {
            ID = Guid.NewGuid();
        }
    }
}
