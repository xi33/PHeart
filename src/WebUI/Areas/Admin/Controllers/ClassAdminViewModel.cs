using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace WebUI.Areas.Admin.Controllers
{
    public class ClassAdminViewModel
    {
        public class FstModel
        {
            public IQueryable<FstClass> FstClasses { get; set; }
        }

        public class EditFstModel
        {
            public FstClass FstClassToEdit { get; set; }
        }

        public class SndModel
        {
            public IQueryable<SndClass> SndClasses { get; set; }
            public FstClass FstClass { get; set; }
            public SndClass SndClassToAdd { get; set; }
        }

        public class EditSndModel
        {
            public int FstClassId { get; set; }
            public SndClass SndClassToEdit { get; set; }
        }
    }
}