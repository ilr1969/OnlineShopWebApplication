﻿using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class UserRoleInMemoryStorage : IUserRoleStorage
    {
        public List<UserRoleClass> userRoles = new List<UserRoleClass>()
        {
            new UserRoleClass() {RoleName = "Admin", RoleDescription = "Full rights"}
        };
        public List<UserRoleClass> GetRolesList()
        {
            return userRoles;
        }
        public UserRoleClass GetRole(Guid userRoleId)
        {
            return userRoles.FirstOrDefault(x => x.Id == userRoleId);
        }
        public void AddUserRole(UserRoleClass userRole)
        {
            userRoles.Add(userRole);
        }
        public void RemoveUserRole(UserRoleClass userRole)
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