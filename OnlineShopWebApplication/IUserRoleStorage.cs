using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IUserRoleStorage
    {
        static List<UserRoleClass> userRole;
        List<UserRoleClass> GetRolesList();
        UserRoleClass GetRole(Guid userRoleId);
        void AddUserRole(UserRoleClass userRole);
        void RemoveUserRole(UserRoleClass userRole);
    }
}
