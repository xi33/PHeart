using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Authentication;
using Domain.Authentication.Internal;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;
using WebUI.Application.Authentication;

namespace WebUI.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthenticator authenticator;

        public AuthController(IUserRepository repository)
        {
            authenticator = new FormsAuthenticator(repository);
        }

        public PlogMembershipProvider PlogMembershipProvider = new PlogMembershipProvider();

        public ActionResult Login(string returnUrl)
        {
            ModelState.Clear();
            var model = new AuthViewModel.LoginModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(AuthViewModel.LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var authenticated = authenticator.AuthenticateAndLogin(model.Username, model.Password);
            if (authenticated)
            {
                string ReturnUrl = model.ReturnUrl;
                if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/")
                        && !ReturnUrl.StartsWith("//") && !ReturnUrl.StartsWith("/\\"))
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Dashboard");
            }
            ModelState.AddModelError("", "Invalid username or password. Please try again.");
            return View(model);
        }

        public ActionResult LogOut()
        {
            authenticator.Logout();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult CreateNewUser(AccountViewModel.UsersModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PlogMembershipProvider.CreateUser(
                        model.UserToAdd.Name, model.UserToAdd.Password, model.UserToAdd.Email,
                        model.RoleId
                    );
                    authenticator.AuthenticateAndLogin(model.UserToAdd.Name, model.UserToAdd.Password);
                    return RedirectToAction("Index", "Dashboard");
                }
                catch (ArgumentException ae)
                {
                    ModelState.AddModelError("", ae.Message);
                }
            }
            return RedirectToAction("Users", "Account");
        }


    }
}
