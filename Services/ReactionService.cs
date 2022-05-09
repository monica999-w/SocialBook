using SocialBook.Models;
using SocialBook.Repositories.Interfaces;
using SocialBook.Services.Interfaces;

namespace SocialBook.Service
{
    public class ReactionService : IReactionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ReactionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<Reaction> GetReactionByType(string reactionType)
        {
            var reactions = new List<Reaction>();

            return reactions;
        }
    }
}