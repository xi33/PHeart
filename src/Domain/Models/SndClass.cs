using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class SndClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FstClassId { get; set; }

        public ICollection<News> Newses { get; set; }

    }
}
