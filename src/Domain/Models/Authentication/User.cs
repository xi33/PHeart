using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models.Authentication
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Username == Name
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual IList<Role> Roles { get; protected set; }

    }
}
