using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Database.Models
{
    public class User : IdentityUser
    {
        public string Description { get; set; }
        public List<Image> Photos { get; set; }

        public User()
        {
            Photos = new List<Image>();
        }
    }
}
