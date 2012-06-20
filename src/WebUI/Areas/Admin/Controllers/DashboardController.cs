using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories.Authentication;
using Domain.Services.Authentication;

namespace WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {

        public readonly UserService userService;

        public DashboardController(IUserRepository repository)
        {
            userService=new UserService(repository);
        }

        public ActionResult Index()
        {
            var model = new DashboardViewModel.IndexModel() {Users = userService.Users};
            return View(model);
        }

    }
}
