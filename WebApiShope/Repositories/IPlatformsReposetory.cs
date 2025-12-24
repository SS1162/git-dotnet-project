using Entities;

namespace Repositories
{
    public interface IPlatformsReposetory
    {
        Task<Platform> AddPlatformReposetory(Platform platform);
        Task<bool> DeletePlatformReposetory(int id);
        Task<IEnumerable<Platform>> GetPlatformsReposetory();
        Task UpdatePlatformReposetory(int id, Platform platform);
    }
}