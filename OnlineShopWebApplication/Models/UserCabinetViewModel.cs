using OnlineShop.Database.Models;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Models
{
    public class UserCabinetViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public List<UserImages> UserImages { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
