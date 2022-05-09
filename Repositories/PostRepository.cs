using SocialBook.Repositories;
using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;

namespace SocialBook.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(SocialBookContext postContext)
               : base(postContext)
        {
        }
    }
}