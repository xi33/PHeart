using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Controllers
{
    public class NewsViewModel
    {
        public class ListModel
        {
            public SndClass ActivateSndClass { get; set; }
            public IQueryable<SndClass> SndClasses { get; set; }
            public IQueryable<News> ActivateNewsList { get; set; }
        }

        public class ContentModel 
        {
            public SndClass ActivateSndClass { get; set; }
            public IQueryable<SndClass> SndClasses { get; set; }
            public News News { get; set; }
        }
    }
}