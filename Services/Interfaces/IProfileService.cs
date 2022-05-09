using SocialBook.Models;

namespace SocialBook.Services.Interfaces
{
    public interface IProfileService
    {
        List<Profile> GetProfileByType(string profileType);
    }
}
