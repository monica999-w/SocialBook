using SocialBook.Repositories;
using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;

namespace SocialBook.Repositories
{
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(SocialBookContext profileContext)
               : base(profileContext)
        {
        }
    }
}