using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories;
using Domain.Services;

namespace WebUI.Controllers
{
    public class NewsController : Controller
    {
        #region DI
        private readonly NewsService newsService;

        public NewsController(
            IFstClassRepository fstClassRepository,
            ISndClassRepository sndClassRepository,
            INewsRepository newsRepository
            )
        {
            newsService = new NewsService(fstClassRepository, sndClassRepository, newsRepository);
        }
        #endregion

        public ActionResult List(int fstClassId, int sndClassId = 0)
        {
            ViewBag.FstClasses = newsService.FstClasses.AsEnumerable().OrderBy(_ => _.Id).AsQueryable();

            var model = new NewsViewModel.ListModel();
            model.SndClasses = newsService.GetSndClassesByFstClassId(fstClassId);
            if (sndClassId == 0)
            {
                model.ActivateSndClass = model.SndClasses.Take(1).SingleOrDefault();
            }
            else
            {
                model.ActivateSndClass = model.SndClasses.SingleOrDefault(snd => snd.Id == sndClassId);
            }
            model.ActivateNewsList = newsService.GetNewsListBySndClassId(model.ActivateSndClass.Id);
            return View(model);
        }

        public ActionResult Content(int id)
        {
            ViewBag.FstClasses = newsService.FstClasses.AsEnumerable().OrderBy(_ => _.Id).AsQueryable();

            newsService.AddNewsView(id);
            var model = new NewsViewModel.ContentModel();
            model.News = newsService.GetNewsById(id);
            model.ActivateSndClass = model.News.SndClass;
            model.SndClasses = newsService.GetSndClassesByFstClassId(model.ActivateSndClass.FstClassId);
            return View(model);
        }

    }
}
