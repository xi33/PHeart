using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Authentication;
using Domain.Authentication.Internal;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;

namespace WebUI.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthenticator authenticator;

        public AuthController(IUserRepository repository)
        {
            authenticator=new FormsAuthenticator(repository);
        }

        public ActionResult Login ()
        {
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthViewModel.LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var authenticated = authenticator.AuthenticateAndLogin(model.Username, model.Password);
            if(authenticated)
            {
                return RedirectToAction("Index","Dashboard");
            }
            ModelState.AddModelError("", "Invalid username or password. Please try again.");
            return View(model);
        }

        public ActionResult LogOut()
        {
            authenticator.Logout();
            return RedirectToAction("Login");
        }

    }
}
