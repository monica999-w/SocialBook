using SocialBook.Repositories;
using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;

namespace SocialBook.Repositories
{
    public class ReactionRepository : RepositoryBase<Reaction>, IReactionRepository
    {
        public ReactionRepository(SocialBookContext reactionContext)
               : base(reactionContext)
        {
        }
        
        public async Task<Reaction?> GetById(int id) => await context.Reaction.FindAsync(id);
        
        public async void Save(Reaction comment)
        {
          

            context.Add(comment);
            await context.SaveChangesAsync();
        }

        public async void Update(Reaction reaction)
        {
           

            context.Update(reaction);
            await context.SaveChangesAsync();
        }

        public async void Remove(Reaction reaction)
        {
            context.Remove(reaction);
            await context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return context.Reaction.Any(e => e.Id == id);
        }

        public List<Reaction> GetList()
        {
            return context.Reaction.ToList();
        }
    }
}