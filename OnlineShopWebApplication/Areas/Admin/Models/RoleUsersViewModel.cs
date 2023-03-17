using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Database.Models;

namespace OnlineShopWebApplication.Areas.Admin.Models
{
    public class RoleUsersViewModel
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public List<string> UsersInRole { get; set; }
    }
}
