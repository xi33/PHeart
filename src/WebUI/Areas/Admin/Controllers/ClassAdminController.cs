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
    //[Authorize(Roles = "Administrator")]
    public class ClassAdminController : Controller
    {

        #region DI
        private readonly NewsService newsService;

        public ClassAdminController(
            IFstClassRepository fstClassRepository,
            ISndClassRepository sndClassRepository,
            INewsRepository newsRepository
            )
        {
            newsService = new NewsService(fstClassRepository, sndClassRepository, newsRepository);
        }
        #endregion

        public ActionResult Fst()
        {
            var model = new ClassAdminViewModel.FstModel();
            model.FstClasses = newsService.FstClasses;
            return View(model);
        }

        public ActionResult EditFst(int id)
        {
            var model = new ClassAdminViewModel.EditFstModel();
            model.FstClassToEdit = newsService.GetFstClassById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditFst(ClassAdminViewModel.EditFstModel model)
        {
            var fstClassToUpdate = model.FstClassToEdit;
            if (ModelState.IsValid)
            {
                newsService.UpdateFstClass(fstClassToUpdate);
                return RedirectToAction("Fst");
            }
            return View(model);
        }

        public ActionResult Snd(int fstId)
        {
            var model = new ClassAdminViewModel.SndModel();
            model.FstClass = newsService.GetFstClassById(fstId);
            model.SndClasses = newsService.GetSndClassesByFstClassId(fstId);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSnd(ClassAdminViewModel.SndModel model)
        {
            var sndClassToAdd = new SndClass()
                                    {
                                        Name = model.SndClassToAdd.Name,
                                        FstClassId = model.FstClass.Id
                                    };
            newsService.AddSndClass(sndClassToAdd);
            return RedirectToAction("Snd", new { fstId = model.FstClass.Id });
        }

        public ActionResult EditSnd(int id)
        {
            var model = new ClassAdminViewModel.EditSndModel();
            model.SndClassToEdit = newsService.GetSndClassById(id);
            model.FstClassId = model.SndClassToEdit.FstClassId;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditSnd(ClassAdminViewModel.EditSndModel model)
        {
            var sndClassToUpdate = new SndClass()
                                       {
                                           Id = model.SndClassToEdit.Id,
                                           Name = model.SndClassToEdit.Name,
                                           FstClassId = model.FstClassId
                                       };
            if (ModelState.IsValid)
            {
                newsService.UpdateSndClass(sndClassToUpdate);
                return RedirectToAction("Snd", "ClassAdmin", new { fstId = model.FstClassId });
            }
            return View(model);
        }
    }
}
