
using SocialBook.Models;

namespace SocialBook.Repositories.Interfaces
{
    public interface ICommentRepository: IRepositoryBase<Comment>
    {
        public List<Comment> GetList();

        public Task<Comment?> GetById(int id);

        public void Save(Comment comment);
        public void Remove(Comment comment);

        public bool Exists(int id);
    }
}
