using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Authentication
{
    public interface IAuthenticator
    {
        bool AuthenticateAndLogin(string username, string password);
        bool ValidateUser(string username, string password);
        void Logout();
    }
}
