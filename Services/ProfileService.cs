using SocialBook.Models;
using SocialBook.Repositories.Interfaces;
using SocialBook.Services.Interfaces;

namespace SocialBook.Service
{
    public class ProfileService : IProfileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProfileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<Profile> GetProfileByType(string profileType)
        {
            var profiles = new List<Profile>();

            return profiles;
        }
    }
}
