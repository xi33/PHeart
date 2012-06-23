using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Controllers
{
    public class HomeViewModel
    {
        public IQueryable<News> News1 { get; set; }
        public IQueryable<News> News2 { get; set; }
        public IQueryable<News> News3 { get; set; }
        public IQueryable<News> News4 { get; set; }
    }


}