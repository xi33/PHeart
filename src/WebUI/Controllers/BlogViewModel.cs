using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;

namespace WebUI.Controllers
{
    public class BlogViewModel
    {
        public class IndexModel
        {
            public IQueryable<Post> Posts { get; set; } 
        }

        public class PostModel
        {
            public Post Post { get; set; }
        }
    }

}