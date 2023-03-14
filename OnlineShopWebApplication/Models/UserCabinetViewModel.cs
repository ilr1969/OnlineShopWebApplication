using System.Collections.Generic;
using OnlineShop.Database.Models;

namespace OnlineShopWebApplication.Models
{
    public class UserCabinetViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public List<Image> Photos { get; set; }
    }
}
