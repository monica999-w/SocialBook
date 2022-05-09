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
    }
}