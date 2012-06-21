using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Controllers
{
    public class NewsViewModel
    {
        public class List
        {
            public SndClass ActivateSndClass { get; set; }
            public IQueryable<SndClass> SndClasses { get; set; }
            public IQueryable<News> ActivateNewsList { get; set; }
        }
    }
}