using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;

namespace Domain.Authentication.Internal
{
    public class FormsRoleProvider : IRoleProvider
    {
        private readonly UserService userService;
        private readonly RoleService roleService;

        public FormsRoleProvider(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            userService=new UserService(userRepository);
            roleService=new RoleService(roleRepository);
        }


        public bool IsUserInRole(string username, string roleName)
        {
            var user = userService.GetUser(username);
            var role = roleService.GetRole(roleName);
            if (user == null || role == null)
                return false;
            return user.Roles.Any(_=>_.Name==roleName);
        }

        public string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
