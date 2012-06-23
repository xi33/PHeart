using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Areas.Admin.Controllers
{
    public class AccountViewModel
    {
        public class RoleModel
        {
            public IQueryable<Role> Roles { get; set; }
        }

        public class UsersModel
        {
            public int RoleId { get; set; }
            public IQueryable<User> Users { get; set; }
            public User UserToAdd { get; set; }
        }
    }
}