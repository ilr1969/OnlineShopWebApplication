using System;

namespace OnlineShopWebApplication.Models
{
    public class UserClass
    {
        public Guid ID;
        public string Name;

        public UserClass(string name)
        {
            Name = name;
        }
    }
}
