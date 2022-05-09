using SocialBook.Models;

namespace SocialBook.Services.Interfaces
{
    public interface IReactionService
    {
        List<Reaction> GetReactionByType(string reactionType);
    }
}
