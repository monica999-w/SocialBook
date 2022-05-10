using SocialBook.Models;

namespace SocialBook.Repositories.Interfaces
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        public Task<Post?> GetById(int id);
        public void Add(Post post);
        public void Modify(Post post);
        public bool Exists(int id);
        public void Delete(Post post);
        public Task<List<Post>> GetList();


    }
}