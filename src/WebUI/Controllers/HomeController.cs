using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories;
using Domain.Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        #region DI
        private readonly NewsService newsService;

        public HomeController(
            IFstClassRepository fstClassRepository,
            ISndClassRepository sndClassRepository,
            INewsRepository newsRepository
            )
        {
            newsService = new NewsService(fstClassRepository, sndClassRepository, newsRepository);
        } 
        #endregion

        public ActionResult Index()
        {
            //var model = new HomeViewModel.Index();
            //model.FstClasses = newsService.FstClasses;
            ViewBag.FstClasses = newsService.FstClasses.AsEnumerable().OrderBy(_ => _.Id).AsQueryable();
            return View();
        }

    }
}
