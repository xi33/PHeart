using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Areas.Admin.Controllers
{
    public class NewsAdminViewModel
    {
        public class NewModel
        {
            //public News NewsToAdd { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public int FstClassId { get; set; }
            public int SndClassId { get; set; }
            public string ImageUrl { get; set; }
            public string Body { get; set; }
        }

        public class EditModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public int FstClassId { get; set; }
            public int SndClassId { get; set; }
            public string ImageUrl { get; set; }
            public string Body { get; set; }
        }

        public class ListModel
        {
            public int SndClassId { get; set; }
            public string SndClassName { get; set; }
            public IQueryable<News> NewsList { get; set; }
        }
    }
}