using SocialBook.Models;

namespace SocialBook.Services.Interfaces
{
    public interface IPostService
    {
        List<Post> GetPostByType(string postType);
    }
}
