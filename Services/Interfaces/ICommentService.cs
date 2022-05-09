using SocialBook.Models;

namespace SocialBook.Services.Interfaces
{
    public interface ICommentService
    {
        List<Comment> GetCommentByType(string commentType);

        Comment GetById(int id);

    }
}
