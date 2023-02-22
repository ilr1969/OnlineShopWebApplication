using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class UserInMemoryStorage : IUserStorage
    {
        public List<UserClass> usersList = new List<UserClass>()
        {
            new UserClass() {Name = "Дмитрий", Password = "123" },
            new UserClass() {Name = "Дмитрий Савченко", Password = "1" }
        };

        public UserClass TryGetUserByName(string name)
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

        public void AddUser(UserClass user)
        {
            usersList.Add(user);
        }

        public List<UserClass> GetAll()
        {
            return usersList;
        }

        public void DeleteUser(Guid userId)
        {
            var userToDelete = usersList.First(x => x.ID == userId);
            usersList.Remove(userToDelete);
        }

        public UserClass TryGetUserById(Guid userId)
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

        public void ChangeUserData(Guid userId, UserClass user)
        {
            var userToEdit = TryGetUserById(userId);
            userToEdit.Name = user.Name;
            userToEdit.Email = user.Email;
            userToEdit.Age = user.Age;
            userToEdit.Role = user.Role;
        }
    }
}
