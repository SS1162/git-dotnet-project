using DTO;

namespace Services
{
    public interface ISiteTypesService
    {
        Task<IEnumerable<SiteTypeDTO>?> GetAllSiteTypesServise();
        Task<SiteTypeDTO?> GetSiteTypesByIdServise(int id);
        Task<Resulte<SiteTypeDTO>> UpdateSiteTypesByMngServise(int id, SiteTypeDTO dto);
    }
}