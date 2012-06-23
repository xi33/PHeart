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
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult New(NewsAdminViewModel.NewModel model)
        {
            var newsToAdd = new News()
                                {
                                    Title = model.Title,
                                    Author = model.Author,
                                    Published = DateTime.Now,
                                    FstClassId = model.FstClassId,
                                    SndClassId=model.SndClassId,
                                    ImageUrl = "",
                                    Body = model.Body
                                };
            newsService.CreateNews(newsToAdd);
            return View();
        }

        public ActionResult Edit(int newsId)
        {
            var model = new NewsAdminViewModel.EditModel();
            model.NewsToEdit = newsService.GetNewsById(newsId);
            model.SndClassId = model.NewsToEdit.SndClassId;
            model.FstClassId = newsService.GetSndClassById(model.SndClassId).FstClassId;
            return View(model);
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
