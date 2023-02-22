using System;
using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IUserStorage
    {
        static List<UserClass> usersList;

        UserClass TryGetUserByName(string name);

        void AddUser(UserClass user);
        List<UserClass> GetAll();
        void DeleteUser(Guid userId);
        UserClass TryGetUserById(Guid userId);
        void changePassword(Guid userId);
        void ChangeUserData(Guid userId, UserClass user);
    }
}
