using OnlineShop.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApi.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Укажите корректный Email")]
        public string? Email { get; set; }

        public string? Description { get; set; }
        public List<UserImages>? Photos { get; set; }

        public string? Error { get; set; }
    }
}
