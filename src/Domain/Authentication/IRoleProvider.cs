using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Authentication
{
    public interface IRoleProvider
    {
        bool IsUserInRole(string username, string roleName);

        string[] GetRolesForUser(string username);
    }
}
