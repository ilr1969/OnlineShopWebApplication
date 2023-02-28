using System;
using System.Collections.Generic;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IUserRoleStorage
    {
        static List<UserRoleViewModel> userRole;
        List<UserRoleViewModel> GetRolesList();
        UserRoleViewModel GetRole(Guid userRoleId);
        void AddUserRole(UserRoleViewModel userRole);
        void RemoveUserRole(UserRoleViewModel userRole);
        void UpdateRole(Guid userRoleId, string roleName, string roleDescription);
    }
}
