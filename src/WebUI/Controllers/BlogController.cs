using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories;
using Domain.Services;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {

        public readonly PostService service;

        public BlogController(IPostRepository repository)
        {
            service = new PostService(repository);
        }


        public ActionResult Index()
        {
            //view model
            var model = new BlogViewModel.IndexModel { Posts = service.Posts };
            return View(model);
        }

        public ActionResult Post(int id = 1)
        {
            var model = new BlogViewModel.PostModel() {Post = service.GetPostById(id)};
            return View(model);
        }


    }
}
