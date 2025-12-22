using DTO;

namespace Services
{
    public interface IBasicSitesServise
    {
        Task<BasicSiteDTO> AddBasicSiteServise(AddBasicSiteDTO BasicSiteToUpdate);
        Task<BasicSiteDTO> GetByIDbasicSiteServise(int id);
        Task UpdateBasicSiteServise(int id, UpdateBasicSiteDTO basicSiteToUpdate);
    }
}