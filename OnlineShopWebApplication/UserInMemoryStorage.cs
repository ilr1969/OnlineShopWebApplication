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
