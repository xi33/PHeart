using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Controllers
{
    public class HomeViewModel
    {
        public class Index
        {
            public IQueryable<FstClass> FstClasses { get; set; }
        }

    }
}