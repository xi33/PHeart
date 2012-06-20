using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Security;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;

namespace Domain.Authentication.Internal
{
    public class FormsAuthenticator:IAuthenticator
    {
        private readonly UserService service;

        public FormsAuthenticator(IUserRepository repository)
        {
            service=new UserService(repository);
        }

        public bool AuthenticateAndLogin(string username, string password)
        {
            bool validated = ValidateUser(username, password);
            if(validated)
            {
                FormsAuthentication.SetAuthCookie(username,true);
            }
            return validated;
        }

        public bool ValidateUser(string username, string password)
        {
            var configName = ConfigurationManager.AppSettings["pheart.configuration.authentication.username"];
            var configPassword = ConfigurationManager.AppSettings["pheart.configuration.authentication.password"];

            if(username==configName && password==configPassword)
            {
                return true;
            }

            if (string.IsNullOrEmpty(password.Trim()) || string.IsNullOrEmpty(username.Trim()))
            {
                return false;
            }

            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "md5");
            return service.Users.Any(u => u.Username == username.Trim() && u.Password == hash);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
