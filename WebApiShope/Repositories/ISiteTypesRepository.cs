using Entities;

namespace Repositories
{
    public interface ISiteTypesRepository
    {
        Task<IEnumerable<SiteType>?> GetAllSiteTypesReposetory();
        Task<SiteType?> GetSiteTypeByIdReposetory(int id);
        Task UpdateSiteTypeByMngReposetory(int id, SiteType siteType);
    }
}