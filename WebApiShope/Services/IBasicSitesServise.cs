using DTO;

namespace Services
{
    public interface IBasicSitesServise
    {
        Task<Resulte<BasicSiteDTO?>> AddBasicSiteServise(AddBasicSiteDTO BasicSiteToAdd);
        Task<BasicSiteDTO> GetByIDbasicSiteServise(int id);
        Task<Resulte<BasicSiteDTO?>> UpdateBasicSiteServise(int id, UpdateBasicSiteDTO basicSiteToUpdate);
    }
}