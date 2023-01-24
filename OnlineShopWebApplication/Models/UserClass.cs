using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
