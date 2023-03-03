using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Database.Models;

namespace OnlineShop.Database
{
    public class UserDbStorage : IUserStorage
    {
        public List<User> usersList = new List<User>()
        {
            new User() {Name = "Дмитрий", Password = "123" },
            new User() {Name = "Дмитрий Савченко", Password = "1" }
        };

        public User TryGetUserByName(string name)
        {
            if (name != null)
            {
                return usersList.FirstOrDefault(user => user.Name == name);
            }
            else
            {
                return null;
            }
        }

        public void AddUser(User user)
        {
            usersList.Add(user);
        }

        public List<User> GetAll()
        {
            return usersList;
        }

        public void DeleteUser(Guid userId)
        {
            var userToDelete = usersList.First(x => x.ID == userId);
            usersList.Remove(userToDelete);
        }

        public User TryGetUserById(Guid userId)
        {
            return usersList.First(x => x.ID == userId);
        }

        public void changePassword(Guid userId)
        {
            var user = usersList.First(x => x.ID == userId);
            Random random = new Random();
            string randomPass = "";
            for (int i = 0; i < 10; i++)
            {
                randomPass += Convert.ToChar(random.Next(33, 125));
            }
            user.Password = randomPass;
        }

        public void ChangeUserData(Guid userId, User user)
        {
            var userToEdit = TryGetUserById(userId);
            userToEdit.Name = user.Name;
            userToEdit.Email = user.Email;
            userToEdit.Age = user.Age;
            userToEdit.Role = user.Role;
        }
    }
}
