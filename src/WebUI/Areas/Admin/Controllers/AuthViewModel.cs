using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Areas.Admin.Controllers
{
    public class AuthViewModel
    {
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}