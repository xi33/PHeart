using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;

namespace WebUI.Areas.Admin.Controllers
{
    public class NewsAdminController : Controller
    {

        #region DI
        private readonly NewsService newsService;

        public NewsAdminController(
            IFstClassRepository fstClassRepository,
            ISndClassRepository sndClassRepository,
            INewsRepository newsRepository
            )
        {
            newsService = new NewsService(fstClassRepository, sndClassRepository, newsRepository);
        }
        #endregion

        public ActionResult List()
        {
            var model = new NewsAdminViewModel.ListModel();
            var sndClass = newsService.FstClasses.Take(1).SingleOrDefault().SndClass.Take(1).SingleOrDefault();
            model.NewsList = newsService.GetNewsListBySndClassId(sndClass.Id);
            model.SndClassName = sndClass.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult List(NewsAdminViewModel.ListModel model)
        {
            model.NewsList = newsService.GetNewsListBySndClassId(model.SndClassId);
            model.SndClassName = newsService.GetSndClassById(model.SndClassId).Name;
            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult New(NewsAdminViewModel.NewModel model)
        {
            if(string.IsNullOrEmpty(model.ImageUrl))
            {
                model.ImageUrl = "";
            }
            var newsToAdd = new News()
                                {
                                    Title = model.Title,
                                    Author = model.Author,
                                    Published = DateTime.Now,
                                    FstClassId = model.FstClassId,
                                    SndClassId = model.SndClassId,
                                    ImageUrl = model.ImageUrl,
                                    Body = model.Body
                                };
            newsService.CreateNews(newsToAdd);
            return View();
        }

        public ActionResult Edit(int newsId)
        {
            var model = new NewsAdminViewModel.EditModel();
            var news = newsService.GetNewsById(newsId);
            model.Id = newsId;
            model.Title = news.Title;
            model.Author = news.Author;
            model.FstClassId = news.FstClassId;
            model.SndClassId = news.SndClassId;
            model.ImageUrl = news.ImageUrl;
            model.Body = news.Body;
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsAdminViewModel.EditModel model)
        {
            if(string.IsNullOrEmpty(model.ImageUrl))
            {
                model.ImageUrl = "";
            }
            var newsToUpdate = newsService.GetNewsById(model.Id);
            newsToUpdate.Title = model.Title;
            newsToUpdate.Author = model.Author;
            newsToUpdate.Published = DateTime.Now.Date;
            newsToUpdate.FstClassId = model.FstClassId;
            newsToUpdate.SndClassId = model.SndClassId;
            newsToUpdate.ImageUrl = model.ImageUrl;
            newsToUpdate.Body = model.Body;
            newsService.UpdateNews(newsToUpdate);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int newsId)
        {
            newsService.DeleteNews(newsId);
            return RedirectToAction("List");
        }

        #region Get ClassList
        [HttpPost]
        public ActionResult GetFstClasses()
        {
            try
            {
                var fstClassList = newsService.FstClasses;
                var returndata = from fstClass in fstClassList
                                 select new
                                            {
                                                Id = fstClass.Id,
                                                Name = fstClass.Name
                                            };
                return Json(new { ok = true, data = returndata, message = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult GetSndClasses(int fstId)
        {
            try
            {
                var sndClassList = newsService.GetSndClassesByFstClassId(fstId);
                var returndata = from sndClass in sndClassList
                                 where sndClass.FstClassId == fstId
                                 select new
                                            {
                                                Id = sndClass.Id,
                                                Name = sndClass.Name
                                            };
                return Json(new { ok = true, data = returndata, message = "ok" });

            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
        }
        #endregion

    }
}
