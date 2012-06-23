using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Security;
using Domain.Models;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;

namespace Domain.Authentication.Internal
{
    public class FormsMembershipProvider : IMembershipProvider
    {
        private readonly UserService service;

        public FormsMembershipProvider(IUserRepository repository)
        {
            service = new UserService(repository);
        }

        public void CreateUser(string name, string password, string email, int roleId)
        {
            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "md5");
            var user = new User() { Name = name, Email = email, Password = hash, RoleId = roleId };
            service.CreateNewUser(user);
        }

        public bool ValidateUser(string name, string password)
        {
            //var configName = ConfigurationManager.AppSettings["pheart.configuration.authentication.username"];
            //var configPassword = ConfigurationManager.AppSettings["pheart.configuration.authentication.password"];

            //if (name == configName && password == configPassword)
            //{
            //    return true;
            //}

            if (string.IsNullOrEmpty(password.Trim()) || string.IsNullOrEmpty(name.Trim()))
            {
                return false;
            }

            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "md5");
            return service.Users.Any(u => u.Name == name.Trim() && u.Password == hash);
        }

        public IEnumerable<User> GetUsers()
        {
            return service.Users;
        }
    }
}
