using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Domain.Models.Authentication;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;

namespace Domain.Authentication.Internal
{
    public class FormsPlogMembershipProvider:IMembershipProvider
    {
        private readonly UserService service;

        public FormsPlogMembershipProvider(IUserRepository repository)
        {
            service=new UserService(repository);
        }

        public void CreateUser(string email, string username, string password)
        {
            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "md5");
            var user = new User() { Name = username, Email = email, Username = username, Password = hash };
            service.CreateNewUser(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return service.Users;
        }
    }
}
