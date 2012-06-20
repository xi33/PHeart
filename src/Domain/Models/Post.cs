using System;

namespace Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public string Body { get; set; }

    }
}
