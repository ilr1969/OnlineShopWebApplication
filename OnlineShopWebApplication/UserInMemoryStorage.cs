using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class UserInMemoryStorage : IUserStorage
    {
        public List<UserClass> usersList = new List<UserClass>()
        {
            new UserClass("Дмитрий", "123"),
            new UserClass("Дмитрий Савченко", "1")
        };

        public UserClass TryGetUser(string name)
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
    }
}
