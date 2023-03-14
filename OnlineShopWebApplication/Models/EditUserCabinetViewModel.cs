using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using OnlineShop.Database.Models;

namespace OnlineShopWebApplication.Models
{
    public class EditUserCabinetViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public List<Image> Photos { get; set; }
        public IFormFile Image { get; set; }
    }
}
