using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class UserStorage : IUserStorage
    {
        public List<UserClass> usersList = new List<UserClass>();

        public UserClass GetUser(string name)
        {
            return usersList.First(user => user.Name == name);
        }

        public void AddUser(UserClass user)
        {
            usersList.Add(user);
        }
    }
}
