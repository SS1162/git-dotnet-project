using DTO;

namespace Services
{
    public interface IPlatformsServise
    {
        Task<PlatformsDTO> AddPlatformServise(AddPlatformDTO platformToAdd);
        Task<bool> DeletePlatformServise(int id);
        Task<IEnumerable<PlatformsDTO>> GetPlatformsServise();
        Task UpdatePlatformServise(int id, PlatformsDTO platform);
    }
}