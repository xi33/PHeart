using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Areas.Admin.Controllers
{
    public class DashboardViewModel
    {
        public class IndexModel
        {
            public IQueryable<User> Users { get; set; }
        }
    }
}