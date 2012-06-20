using System.Linq;
using Domain.Models;
using Domain.Repositories;

namespace Data
{
    public class PostRepository:Repository<Post>,IPostRepository
    {

    }
}
