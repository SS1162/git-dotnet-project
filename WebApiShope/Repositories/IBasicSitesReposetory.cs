using Entities;

namespace Repositories
{
    public interface IBasicSitesReposetory
    {
        Task<BasicSite> AddBasicSiteReposetory(BasicSite basicSiteToUpdate);
        Task<BasicSite?> GetByIDBasicSiteReposetory(int id);
        Task UpdateBasicSiteReposetory(int id, BasicSite basicSiteToUpdate);
        public Task<BasicSite?> CheckIfHasPlatformByPlatformID(int id);
    }
}