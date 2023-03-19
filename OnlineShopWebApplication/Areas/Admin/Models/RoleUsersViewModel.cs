using System.Collections.Generic;

namespace OnlineShopWebApplication.Areas.Admin.Models
{
    public class RoleUsersViewModel
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public List<string> UsersInRole { get; set; }
    }
}
