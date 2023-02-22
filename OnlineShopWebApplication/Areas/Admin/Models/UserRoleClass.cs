using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class UserRoleClass
    {
        public Guid Id;

        [Required(ErrorMessage = "Укажите название роли")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Укажите назначение роли")]
        public string RoleDescription { get; set; }

        public UserRoleClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
