using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IUserStorage
    {
        static List<UserClass> usersList;

        UserClass GetUser(string name);

        void AddUser(UserClass user);
    }
}
