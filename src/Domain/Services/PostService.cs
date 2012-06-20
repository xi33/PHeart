using System.Linq;
using Domain.Models;
using Domain.Repositories;

namespace Domain.Services
{
    public class PostService
    {
        private readonly IPostRepository repository;

        public PostService(IPostRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<Post> Posts
        {
            get { return repository.GetAll(); }
        }

        public Post GetPostById(int id)
        {
            return repository.Get(id);
        }

    }
}
