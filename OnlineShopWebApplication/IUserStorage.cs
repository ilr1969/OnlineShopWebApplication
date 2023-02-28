using System;
using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IUserStorage
    {
        static List<UserViewModel> usersList;

        UserViewModel TryGetUserByName(string name);

        void AddUser(UserViewModel user);
        List<UserViewModel> GetAll();
        void DeleteUser(Guid userId);
        UserViewModel TryGetUserById(Guid userId);
        void changePassword(Guid userId);
        void ChangeUserData(Guid userId, UserViewModel user);
    }
}
