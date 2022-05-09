using SocialBook.Models;
using SocialBook.Repositories.Interfaces;
using SocialBook.Services.Interfaces;

namespace SocialBook.Service
{
    public class PostService :IPostService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PostService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<Post> GetPostByType(string postType)
        {
            var posts = new List<Post>();

            return posts;
        }
    }
}
