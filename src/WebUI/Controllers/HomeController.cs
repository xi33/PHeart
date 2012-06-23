using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;
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
            ViewBag.FstClasses = newsService.FstClasses.AsEnumerable().OrderBy(_ => _.Id).AsQueryable();

            ViewBag.IndexNews = newsService.NewsListWithImage.Take(4);
            var list = newsService.FstClasses.Take(4);
            var model = new HomeViewModel();
            model.News1 = newsService.GetNewsByFstClassId(1);
            model.News2 = newsService.GetNewsByFstClassId(2);
            model.News3 = newsService.GetNewsByFstClassId(3);
            model.News4 = newsService.GetNewsByFstClassId(4);
            return View(model);
        }

    }
}
