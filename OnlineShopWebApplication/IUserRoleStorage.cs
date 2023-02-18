using System;
using System.Collections.Generic;
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
        void UpdateRole(Guid userRoleId, string roleName, string roleDescription);
    }
}
