using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models.Authentication;

namespace Domain.Authentication
{
    public interface IMembershipProvider
    {
        //bool ValidateUser(string username, string password);

        void CreateUser(string email, string username, string password);
        bool ValidateUser(string username, string password);
        IEnumerable<User> GetUsers();

    }
}
