using System;
using System.Collections.Generic;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public interface IUserStorage
    {
        static List<User> usersList;

        User TryGetUserByName(string name);

        void AddUser(User user);
        List<User> GetAll();
        void DeleteUser(Guid userId);
        User TryGetUserById(Guid userId);
        void changePassword(Guid userId);
        void ChangeUserData(Guid userId, User user);
    }
}
