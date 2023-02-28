using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class UserRoleInMemoryStorage : IUserRoleStorage
    {
        public List<UserRoleViewModel> userRoles = new List<UserRoleViewModel>()
        {
            new UserRoleViewModel() {RoleName = "Admin", RoleDescription = "Full rights"}
        };
        public List<UserRoleViewModel> GetRolesList()
        {
            return userRoles;
        }
        public UserRoleViewModel GetRole(Guid userRoleId)
        {
            return userRoles.FirstOrDefault(x => x.Id == userRoleId);
        }
        public void AddUserRole(UserRoleViewModel userRole)
        {
            userRoles.Add(userRole);
        }
        public void RemoveUserRole(UserRoleViewModel userRole)
        {
            userRoles.Remove(userRole);
        }

        public void UpdateRole(Guid userRoleId, string roleName, string roleDescription)
        {
            var UserRoleToEdit = GetRole(userRoleId);
            UserRoleToEdit.RoleName = roleName;
            UserRoleToEdit.RoleDescription = roleDescription;
        }
    }
}
