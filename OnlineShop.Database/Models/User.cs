using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.Database.Models
{
    public class User : IdentityUser
    {
        public string Description { get; set; }
        public List<UserImages> UserImages { get; set; }

        public User()
        {
            UserImages = new List<UserImages>();
        }
    }
}
