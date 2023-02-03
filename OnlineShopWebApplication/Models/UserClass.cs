using System;

namespace OnlineShopWebApplication.Models
{
    public class UserClass
    {
        public Guid ID;
        public string Name;
        public string Password;

        public UserClass(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
