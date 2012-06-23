using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;

namespace WebUI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region DI
        private readonly RoleService roleSerive;
        private readonly UserService userService;

        public AccountController(
            IRoleRepository roleRepository,
            IUserRepository userRepository
            )
        {
            roleSerive = new RoleService(roleRepository);
            userService=new UserService(userRepository);
        }
        #endregion

        public ActionResult Role()
        {
            var model = new AccountViewModel.RoleModel();
            model.Roles = roleSerive.Roles;
            return View(model);
        }

        public ActionResult Users(int roleId)
        {
            var model = new AccountViewModel.UsersModel();
            model.RoleId = roleId;
            model.Users = userService.GetUsersByRoleId(roleId);
            return View(model);
        }

    }
}
