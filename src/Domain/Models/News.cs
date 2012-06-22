using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public int Views { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }

        public int FstClassId { get; set; }
        public int SndClassId { get; set; }
    }
}
