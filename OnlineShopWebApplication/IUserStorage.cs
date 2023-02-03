using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IUserStorage
    {
        static List<UserClass> usersList;

        UserClass TryGetUser(string name);

        void AddUser(UserClass user);
    }
}
