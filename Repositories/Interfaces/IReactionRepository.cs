using SocialBook.Models;

namespace SocialBook.Repositories.Interfaces
{
    public interface IReactionRepository : IRepositoryBase<Reaction>
    {
        public List<Reaction> GetList();

        public Task<Reaction?> GetById(int id);

        public void Save(Reaction reaction);
        public void Remove(Reaction reaction);

        public bool Exists(int id);
    }
}